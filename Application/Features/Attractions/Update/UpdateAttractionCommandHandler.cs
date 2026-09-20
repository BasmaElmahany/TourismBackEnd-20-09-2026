using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Interfaces;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities.Common;

namespace Tourism.Application.Features.Attractions.Update
{
    public class UpdateAttractionCommandHandler
          : IRequestHandler<UpdateAttractionCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public UpdateAttractionCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<bool>> Handle(
            UpdateAttractionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.Attractions.GetByIdAsync(request.Id, cancellationToken);

                if (entity is null)
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "المعلم السياحي المراد تعديله غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                // 1. Handle main image update
                if (request.ImageFile != null && request.ImageFile.Length > 0)
                {
                    // Clean up previous file if it was locally hosted
                    if (!string.IsNullOrWhiteSpace(entity.ImageUrl) && entity.ImageUrl.StartsWith("/assets/images/"))
                    {
                        _fileStorage.DeleteFile(entity.ImageUrl);
                    }

                    entity.ImageUrl = await _fileStorage.SaveFileAsync(request.ImageFile, "attractions", cancellationToken);
                }
                else if (!string.IsNullOrWhiteSpace(request.ExistingImageUrl))
                {
                    entity.ImageUrl = request.ExistingImageUrl;
                }

                // 2. Handle gallery image update
                var finalGallery = request.ExistingGalleryUrls ?? new List<string>();

                // Identify and remove deleted gallery items from disk
                var deletedGalleryImages = entity.ImageGallery.Except(finalGallery).ToList();
                foreach (var deletedImage in deletedGalleryImages)
                {
                    if (deletedImage.StartsWith("/assets/images/"))
                    {
                        _fileStorage.DeleteFile(deletedImage);
                    }
                }

                // Upload new gallery files if supplied
                if (request.NewImageGalleryFiles != null && request.NewImageGalleryFiles.Any())
                {
                    var uploadedGallery = await _fileStorage.SaveFilesAsync(request.NewImageGalleryFiles, "attractions", cancellationToken);
                    finalGallery.AddRange(uploadedGallery);
                }

                entity.ImageGallery = finalGallery;

                // 3. Update entity fields
                entity.Name = new LocalizedText { En = request.Name.En, Ar = request.Name.Ar };
                entity.Description = new LocalizedText { En = request.Description.En, Ar = request.Description.Ar };
                entity.Latitude = request.Latitude;
                entity.Longitude = request.Longitude;
                entity.OpeningHours = new LocalizedText { En = request.OpeningHours.En, Ar = request.OpeningHours.Ar };
                entity.TicketPrice = new LocalizedText { En = request.TicketPrice.En, Ar = request.TicketPrice.Ar };
                entity.BookingUrl = request.BookingUrl;
                entity.Rating = request.Rating;
                entity.ReviewCount = request.ReviewCount;
                entity.Category = new LocalizedText { En = request.Category.En, Ar = request.Category.Ar };
                entity.Features = request.Features?.Select(f => new LocalizedText { En = f.En, Ar = f.Ar }).ToList() ?? new List<LocalizedText>();
                entity.HistoricalPeriod = request.HistoricalPeriod is null ? null : new LocalizedText { En = request.HistoricalPeriod.En, Ar = request.HistoricalPeriod.Ar };
                entity.Significance = request.Significance is null ? null : new LocalizedText { En = request.Significance.En, Ar = request.Significance.Ar };

                _unitOfWork.Attractions.Update(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "تم تعديل المعلم السياحي والملفات بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = $"حدث خطأ أثناء تعديل المعلم السياحي: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}