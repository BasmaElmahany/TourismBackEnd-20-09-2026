using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.Attractions.Update
{
    public record UpdateAttractionCommand(
         string Id,
         LocalizedTextDto Name,
         LocalizedTextDto Description,
         IFormFile? ImageFile,                     // Optional: upload a new main image
         string? ExistingImageUrl,                 // Keeps the current main image if no new file is uploaded
         List<IFormFile>? NewImageGalleryFiles,     // Optional: new gallery images to add
         List<string>? ExistingGalleryUrls,        // Existing gallery images retained by the user
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
     ) : IRequest<ApiResponse<bool>>;
}
