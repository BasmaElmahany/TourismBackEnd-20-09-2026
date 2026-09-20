using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.Attractions.Create
{
    public record CreateAttractionCommand(
         LocalizedTextDto Name,
         LocalizedTextDto Description,
         IFormFile? ImageFile,                     // صورة رئيسية
         List<IFormFile>? ImageGalleryFiles,        // صور المعرض
         double Latitude,
         double Longitude,
         LocalizedTextDto OpeningHours,
         LocalizedTextDto TicketPrice,
         string? BookingUrl,
         double Rating,
         int ReviewCount,
         LocalizedTextDto Category,
         List<LocalizedTextDto> Features,
         LocalizedTextDto? HistoricalPeriod,
         LocalizedTextDto? Significance
     ) : IRequest<ApiResponse<AttractionDto>>;
}
