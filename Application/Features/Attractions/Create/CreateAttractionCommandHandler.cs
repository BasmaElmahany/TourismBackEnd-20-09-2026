using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.Interfaces;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities;
using Tourism.Domain.Entities.Common;

namespace Tourism.Application.Features.Attractions.Create
{
    public class CreateAttractionCommandHandler
        : IRequestHandler<CreateAttractionCommand, ApiResponse<AttractionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public CreateAttractionCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<AttractionDto>> Handle(
            CreateAttractionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // حفظ الصورة الرئيسية
                string mainImageUrl = string.Empty;
                if (request.ImageFile != null)
                {
                    mainImageUrl = await _fileStorage.SaveFileAsync(request.ImageFile, "attractions", cancellationToken);
                }

                // حفظ صور المعرض
                List<string> galleryUrls = new();
                if (request.ImageGalleryFiles != null && request.ImageGalleryFiles.Any())
                {
                    galleryUrls = await _fileStorage.SaveFilesAsync(request.ImageGalleryFiles, "attractions", cancellationToken);
                }

                var entity = new Attraction
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = new LocalizedText { En = request.Name.En, Ar = request.Name.Ar },
                    Description = new LocalizedText { En = request.Description.En, Ar = request.Description.Ar },
                    ImageUrl = mainImageUrl,
                    ImageGallery = galleryUrls,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    OpeningHours = new LocalizedText { En = request.OpeningHours.En, Ar = request.OpeningHours.Ar },
                    TicketPrice = new LocalizedText { En = request.TicketPrice.En, Ar = request.TicketPrice.Ar },
                    BookingUrl = request.BookingUrl,
                    Rating = request.Rating,
                    ReviewCount = request.ReviewCount,
                    Category = new LocalizedText { En = request.Category.En, Ar = request.Category.Ar },
                    Features = request.Features?.Select(f => new LocalizedText { En = f.En, Ar = f.Ar }).ToList() ?? new List<LocalizedText>(),
                    HistoricalPeriod = request.HistoricalPeriod is null ? null : new LocalizedText { En = request.HistoricalPeriod.En, Ar = request.HistoricalPeriod.Ar },
                    Significance = request.Significance is null ? null : new LocalizedText { En = request.Significance.En, Ar = request.Significance.Ar }
                };

                await _unitOfWork.Attractions.AddAsync(entity, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var dto = new AttractionDto
                {
                    Id = entity.Id,
                    Name = request.Name,
                    Description = request.Description,
                    ImageUrl = entity.ImageUrl,
                    ImageGallery = entity.ImageGallery,
                    Latitude = entity.Latitude,
                    Longitude = entity.Longitude,
                    OpeningHours = request.OpeningHours,
                    TicketPrice = request.TicketPrice,
                    BookingUrl = entity.BookingUrl,
                    Rating = entity.Rating,
                    ReviewCount = entity.ReviewCount,
                    Category = request.Category,
                    Features = request.Features ?? new List<LocalizedTextDto>(),
                    HistoricalPeriod = request.HistoricalPeriod,
                    Significance = request.Significance
                };

                return new ApiResponse<AttractionDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم إضافة المعلم السياحي وحفظ الصور بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch
            {
                return new ApiResponse<AttractionDto>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ أثناء إضافة المعلم السياحي وحفظ الصور",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}