using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.Tourguide.Create
{
    public record CreateTourGuideCommand(
        LocalizedTextDto Name,
        LocalizedTextDto? Bio,
        List<object>? Languages,
        string? ImageUrl,
        LocalizedTextDto? Phone,
        LocalizedTextDto? Email,
        SocialLinksDto? Social,
        LocationInfoDto? Location,
        double? Rating
    ) : IRequest<ApiResponse<TourGuideDto>>;
}
