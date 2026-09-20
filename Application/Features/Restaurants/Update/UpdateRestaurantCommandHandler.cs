using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities.Common;
using Tourism.Domain.Entities;
using Tourism.Application.Interfaces;

namespace Tourism.Application.Features.Restaurants.Update
{
    public class UpdateRestaurantCommandHandler
         : IRequestHandler<UpdateRestaurantCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public UpdateRestaurantCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<bool>> Handle(
            UpdateRestaurantCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.Restaurants.GetByIdAsync(request.Id, cancellationToken);

                if (entity is null)
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "المطعم المراد تعديله غير موجود",
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

                    entity.ImageUrl = await _fileStorage.SaveFileAsync(request.ImageFile, "restaurants", cancellationToken);
                }
                else if (!string.IsNullOrWhiteSpace(request.ExistingImageUrl))
                {
                    entity.ImageUrl = request.ExistingImageUrl;
                }

                // 2. معالجة صور المعرض وحذف الصور المستبعدة من القرص
                var finalGallery = request.ExistingGalleryUrls ?? new List<string>();

                var deletedGalleryImages = (entity.ImageGallery ?? new List<string>()).Except(finalGallery).ToList();
                foreach (var deletedImage in deletedGalleryImages)
                {
                    if (deletedImage.StartsWith("/assets/images/"))
                    {
                        _fileStorage.DeleteFile(deletedImage);
                    }
                }

                // رفع الصور الجديدة للمعرض إن وُجدت
                if (request.NewImageGalleryFiles != null && request.NewImageGalleryFiles.Any())
                {
                    var uploadedGallery = await _fileStorage.SaveFilesAsync(request.NewImageGalleryFiles, "restaurants", cancellationToken);
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
                entity.CuisineType = new LocalizedText { En = request.CuisineType.En, Ar = request.CuisineType.Ar };
                entity.PriceRange = new LocalizedText { En = request.PriceRange.En, Ar = request.PriceRange.Ar };
                entity.OpeningHours = new LocalizedText { En = request.OpeningHours.En, Ar = request.OpeningHours.Ar };
                entity.Specialties = request.Specialties?.Select(s => new LocalizedText { En = s.En, Ar = s.Ar }).ToList() ?? new List<LocalizedText>();
                entity.Center = request.Center is null ? null : new LocalizedText { En = request.Center.En, Ar = request.Center.Ar };
                entity.MenuUrl = request.MenuUrl?.ToString();
                entity.ContactInfo = new RestaurantContactInfo
                {
                    Phone = new LocalizedText { En = request.ContactInfo.Phone.En, Ar = request.ContactInfo.Phone.Ar },
                    Email = request.ContactInfo.Email
                };
                entity.Features = request.Features?.Select(f => new LocalizedText { En = f.En, Ar = f.Ar }).ToList() ?? new List<LocalizedText>();

                _unitOfWork.Restaurants.Update(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "تم تعديل بيانات المطعم والصور بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = $"حدث خطأ أثناء تعديل بيانات المطعم: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}