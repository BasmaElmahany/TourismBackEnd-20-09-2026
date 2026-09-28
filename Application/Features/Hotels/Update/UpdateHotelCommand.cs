using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.Hotels.Update
{
    public record UpdateHotelCommand(
         string Id,
         LocalizedTextDto Name,
         LocalizedTextDto? Description,
         IFormFile? ImageFile,                      
         string? ExistingImageUrl,                
         List<IFormFile>? NewImageGalleryFiles,     
         List<string>? ExistingGalleryUrls,     
         double? Latitude,
         double? Longitude,
         double? Rating,
         int? ReviewCount,
         LocalizedTextDto? PriceRange,
         List<LocalizedTextDto>? Amenities,
         List<LocalizedTextDto>? RoomTypes,
         HotelContactInfoDto? ContactInfo,
         int? StarRating
     ) : IRequest<ApiResponse<bool>>;
}
