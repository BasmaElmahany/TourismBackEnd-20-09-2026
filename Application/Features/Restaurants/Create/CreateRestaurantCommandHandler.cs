using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities.Common;
using Tourism.Domain.Entities;
using Tourism.Application.Interfaces;

namespace Tourism.Application.Features.Restaurants.Create
{
    public class CreateRestaurantCommandHandler
         : IRequestHandler<CreateRestaurantCommand, ApiResponse<RestaurantDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public CreateRestaurantCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<RestaurantDto>> Handle(
            CreateRestaurantCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. حفظ الصورة الرئيسية داخل wwwroot/assets/images/restaurants
                string mainImageUrl = request.ImageUrl ?? string.Empty;
                if (request.ImageFile != null && request.ImageFile.Length > 0)
                {
                    mainImageUrl = await _fileStorage.SaveFileAsync(request.ImageFile, "restaurants", cancellationToken);
                }

                // 2. حفظ صور المعرض
                var galleryUrls = request.ImageGallery ?? new List<string>();
                if (request.ImageGalleryFiles != null && request.ImageGalleryFiles.Any())
                {
                    var uploadedGallery = await _fileStorage.SaveFilesAsync(request.ImageGalleryFiles, "restaurants", cancellationToken);
                    galleryUrls.AddRange(uploadedGallery);
                }

                var entity = new Restaurant
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = new LocalizedText { En = request.Name.En, Ar = request.Name.Ar },
                    Description = new LocalizedText { En = request.Description.En, Ar = request.Description.Ar },
                    ImageUrl = mainImageUrl,
                    ImageGallery = galleryUrls,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    Rating = request.Rating,
                    ReviewCount = request.ReviewCount,
                    CuisineType = new LocalizedText { En = request.CuisineType.En, Ar = request.CuisineType.Ar },
                    PriceRange = new LocalizedText { En = request.PriceRange.En, Ar = request.PriceRange.Ar },
                    OpeningHours = new LocalizedText { En = request.OpeningHours.En, Ar = request.OpeningHours.Ar },
                    Specialties = request.Specialties?.Select(s => new LocalizedText { En = s.En, Ar = s.Ar }).ToList() ?? new List<LocalizedText>(),
                    Center = request.Center is null ? null : new LocalizedText { En = request.Center.En, Ar = request.Center.Ar },
                    MenuUrl = request.MenuUrl?.ToString(),
                    ContactInfo = new RestaurantContactInfo
                    {
                        Phone = new LocalizedText { En = request.ContactInfo.Phone.En, Ar = request.ContactInfo.Phone.Ar },
                        Email = request.ContactInfo.Email
                    },
                    Features = request.Features?.Select(f => new LocalizedText { En = f.En, Ar = f.Ar }).ToList() ?? new List<LocalizedText>()
                };

                await _unitOfWork.Restaurants.AddAsync(entity, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var dto = new RestaurantDto
                {
                    Id = entity.Id,
                    Name = request.Name,
                    Description = request.Description,
                    ImageUrl = entity.ImageUrl,
                    ImageGallery = entity.ImageGallery,
                    Latitude = entity.Latitude,
                    Longitude = entity.Longitude,
                    Rating = entity.Rating,
                    ReviewCount = entity.ReviewCount,
                    CuisineType = request.CuisineType,
                    PriceRange = request.PriceRange,
                    OpeningHours = request.OpeningHours,
                    Specialties = request.Specialties ?? new List<LocalizedTextDto>(),
                    Center = request.Center,
                    MenuUrl = request.MenuUrl,
                    ContactInfo = request.ContactInfo,
                    Features = request.Features ?? new List<LocalizedTextDto>()
                };

                return new ApiResponse<RestaurantDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم إضافة المطعم وحفظ الصور بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<RestaurantDto>
                {
                    Success = false,
                    Data = null,
                    Message = $"حدث خطأ أثناء إضافة المطعم: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}