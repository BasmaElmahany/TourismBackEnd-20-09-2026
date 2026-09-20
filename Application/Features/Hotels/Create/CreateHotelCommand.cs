using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.Hotels.Create
{
    public record CreateHotelCommand(
         LocalizedTextDto Name,
         LocalizedTextDto Description,
         IFormFile? ImageFile,                     
         List<IFormFile>? ImageGalleryFiles,         
         string? ImageUrl,                          
         List<string>? ImageGallery,               
         double Latitude,
         double Longitude,
         double Rating,
         int ReviewCount,
         LocalizedTextDto PriceRange,
         List<LocalizedTextDto> Amenities,
         List<LocalizedTextDto> RoomTypes,
         HotelContactInfoDto ContactInfo,
         int StarRating
     ) : IRequest<ApiResponse<HotelDto>>;
}
