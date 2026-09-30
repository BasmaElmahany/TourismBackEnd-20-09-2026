using MediatR;
using Microsoft.AspNetCore.Http;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.Hotels.Create
{
    public record CreateHotelCommand(
         LocalizedTextDto Name,                    
         LocalizedTextDto? Description = null,      
         IFormFile? ImageFile = null,             
         List<IFormFile>? ImageGalleryFiles = null,
         string? ImageUrl = null,                  
         List<string>? ImageGallery = null,       
         double? Latitude = null,
         double? Longitude = null,
         double? Rating = null,
         int ReviewCount = 0,
         LocalizedTextDto? PriceRange = null,
         List<LocalizedTextDto>? Amenities = null,
         List<LocalizedTextDto>? RoomTypes = null,
         HotelContactInfoDto? ContactInfo = null,
         int? StarRating = 3
    ) : IRequest<ApiResponse<HotelDto>>;
}
