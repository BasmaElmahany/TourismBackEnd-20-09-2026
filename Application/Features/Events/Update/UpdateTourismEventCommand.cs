using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.Features.DTOs;

namespace Tourism.Application.Features.Events.Update
{
    public record UpdateTourismEventCommand(
         string Id,
         LocalizedTextDto Name,
         LocalizedTextDto Description,
         IFormFile? ImageFile,
         string? ImageUrl,
         DateTime StartDate,
         DateTime EndDate,
         LocalizedTextDto Location,
         double? Latitude,
         double? Longitude,
         LocalizedTextDto? TicketPrice,
         bool IsFree,
         LocalizedTextDto Category,
         LocalizedTextDto? Organizer,
         EventContactInfoDto? ContactInfo
     ) : IRequest<ApiResponse<TourismEventDto>>;
}
