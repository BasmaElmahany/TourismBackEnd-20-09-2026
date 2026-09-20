using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.Restaurants.Create
{
    public record CreateRestaurantCommand(
         LocalizedTextDto Name,
         LocalizedTextDto Description,
         IFormFile? ImageFile,                      // الصورة الرئيسية كملف
         List<IFormFile>? ImageGalleryFiles,         // صور المعرض كملفات
         string? ImageUrl,                          // مسار نصي بديل إذا وُجد
         List<string>? ImageGallery,                // روابط بديلة للمعرض
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
     ) : IRequest<ApiResponse<RestaurantDto>>;
}
