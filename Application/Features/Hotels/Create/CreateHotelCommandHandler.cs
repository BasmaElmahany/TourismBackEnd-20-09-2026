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

namespace Tourism.Application.Features.Hotels.Create
{
    public class CreateHotelCommandHandler
          : IRequestHandler<CreateHotelCommand, ApiResponse<HotelDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public CreateHotelCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<HotelDto>> Handle(
            CreateHotelCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. حفظ الصورة الرئيسية داخل wwwroot/assets/images/hotels
                string mainImageUrl = request.ImageUrl ?? string.Empty;
                if (request.ImageFile != null && request.ImageFile.Length > 0)
                {
                    mainImageUrl = await _fileStorage.SaveFileAsync(request.ImageFile, "hotels", cancellationToken);
                }

                // 2. حفظ صور المعرض داخل wwwroot/assets/images/hotels
                var galleryUrls = request.ImageGallery ?? new List<string>();
                if (request.ImageGalleryFiles != null && request.ImageGalleryFiles.Any())
                {
                    var uploadedGallery = await _fileStorage.SaveFilesAsync(request.ImageGalleryFiles, "hotels", cancellationToken);
                    galleryUrls.AddRange(uploadedGallery);
                }

                var entity = new Hotel
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
                    PriceRange = new LocalizedText { En = request.PriceRange.En, Ar = request.PriceRange.Ar },
                    Amenities = request.Amenities?.Select(a => new LocalizedText { En = a.En, Ar = a.Ar }).ToList() ?? new List<LocalizedText>(),
                    RoomTypes = request.RoomTypes?.Select(r => new LocalizedText { En = r.En, Ar = r.Ar }).ToList() ?? new List<LocalizedText>(),
                    ContactInfo = new HotelContactInfo
                    {
                        Phone = request.ContactInfo.Phone,
                        Email = request.ContactInfo.Phone,
                        Website = request.ContactInfo.Phone
                    },
                    StarRating = request.StarRating
                };

                await _unitOfWork.Hotels.AddAsync(entity, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var dto = new HotelDto
                {
                    Id = entity.Id,
                    Name = request.Name,
                    Description = request.Description,
                    ImageUrl = entity.ImageUrl,
                    ImageGallery = entity.ImageGallery,
                    Latitude = entity.Latitude ?? 0,
                    Longitude = entity.Longitude ?? 0,
                    Rating = entity.Rating ?? 0,
                    ReviewCount = entity.ReviewCount ?? 0,
                    PriceRange = request.PriceRange,
                    Amenities = request.Amenities ?? new List<LocalizedTextDto>(),
                    RoomTypes = request.RoomTypes ?? new List<LocalizedTextDto>(),
                    ContactInfo = request.ContactInfo,
                    StarRating = entity.StarRating ?? 0
                };

                return new ApiResponse<HotelDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم إضافة الفندق وحفظ الصور بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<HotelDto>
                {
                    Success = false,
                    Data = null,
                    Message = $"حدث خطأ أثناء إضافة الفندق: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}