using MediatR;
using Microsoft.AspNetCore.Http;
using Tourism.Application.Common.DTOs;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities.Common;
using Tourism.Domain.Entities;
using Tourism.Application.Interfaces;

namespace Tourism.Application.Features.Hotels.Update
{
    public class UpdateHotelCommandHandler
          : IRequestHandler<UpdateHotelCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public UpdateHotelCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<bool>> Handle(
            UpdateHotelCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.Hotels.GetByIdAsync(request.Id, cancellationToken);

                if (entity is null)
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "الفندق المراد تعديله غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                // 1. معالجة الصورة الرئيسية واستبدال الملف القديم
                if (request.ImageFile != null && request.ImageFile.Length > 0)
                {
                    if (!string.IsNullOrWhiteSpace(entity.ImageUrl) && entity.ImageUrl.StartsWith("/assets/images/"))
                    {
                        _fileStorage.DeleteFile(entity.ImageUrl);
                    }

                    entity.ImageUrl = await _fileStorage.SaveFileAsync(request.ImageFile, "hotels", cancellationToken);
                }
                else if (!string.IsNullOrWhiteSpace(request.ExistingImageUrl))
                {
                    entity.ImageUrl = request.ExistingImageUrl;
                }

                // 2. معالجة صور المعرض وحذف الصور المحذوفة من القرص
                var finalGallery = request.ExistingGalleryUrls ?? new List<string>();

                var deletedGalleryImages = (entity.ImageGallery ?? new List<string>()).Except(finalGallery).ToList();
                foreach (var deletedImage in deletedGalleryImages)
                {
                    if (deletedImage.StartsWith("/assets/images/"))
                    {
                        _fileStorage.DeleteFile(deletedImage);
                    }
                }

                // رفع الصور الجديدة للمعرض
                if (request.NewImageGalleryFiles != null && request.NewImageGalleryFiles.Any())
                {
                    var uploadedGallery = await _fileStorage.SaveFilesAsync(request.NewImageGalleryFiles, "hotels", cancellationToken);
                    finalGallery.AddRange(uploadedGallery);
                }

                entity.ImageGallery = finalGallery;

                // 3. تحديث باقي البيانات
                entity.Name = new LocalizedText { En = request.Name.En, Ar = request.Name.Ar };
                entity.Description = new LocalizedText { En = request.Description.En, Ar = request.Description.Ar };
                entity.Latitude = request.Latitude;
                entity.Longitude = request.Longitude;
                entity.Rating = request.Rating;
                entity.ReviewCount = request.ReviewCount;
                entity.PriceRange = new LocalizedText { En = request.PriceRange.En, Ar = request.PriceRange.Ar };
                entity.Amenities = request.Amenities?.Select(a => new LocalizedText { En = a.En, Ar = a.Ar }).ToList() ?? new List<LocalizedText>();
                entity.RoomTypes = request.RoomTypes?.Select(r => new LocalizedText { En = r.En, Ar = r.Ar }).ToList() ?? new List<LocalizedText>();
                entity.ContactInfo = new HotelContactInfo
                {
                    Phone = request.ContactInfo.Phone ,
                    Email = request.ContactInfo.Email,
                    Website = request.ContactInfo.Website is null ? null : request.ContactInfo.Website
                };
                entity.StarRating = request.StarRating;

                _unitOfWork.Hotels.Update(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "تم تعديل بيانات الفندق والملفات بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = $"حدث خطأ أثناء تعديل بيانات الفندق: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}