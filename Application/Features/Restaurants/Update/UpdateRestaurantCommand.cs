using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.Restaurants.Update
{
    public record UpdateRestaurantCommand(
         string Id,
         LocalizedTextDto Name,
         LocalizedTextDto Description,
         IFormFile? ImageFile,                      // صورة رئيسية جديدة (اختياري)
         string? ExistingImageUrl,                  // الرابط الحالي إن لم تُرفع صورة جديدة
         List<IFormFile>? NewImageGalleryFiles,      // صور معرض جديدة (اختياري)
         List<string>? ExistingGalleryUrls,         // الصور القديمة التي أبقى عليها المستخدم
         double Latitude,
         double Longitude,
         double Rating,
         int ReviewCount,
         LocalizedTextDto CuisineType,
         LocalizedTextDto PriceRange,
         LocalizedTextDto OpeningHours,
         List<LocalizedTextDto> Specialties,
         LocalizedTextDto? Center,
         object? MenuUrl,
         RestaurantContactInfoDto ContactInfo,
         List<LocalizedTextDto> Features
     ) : IRequest<ApiResponse<bool>>;
}
