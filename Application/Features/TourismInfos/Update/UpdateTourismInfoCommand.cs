using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.TourismInfos.Update
{
    public record UpdateTourismInfoCommand(
         string Id,
         LocalizedTextDto Title,
         LocalizedTextDto Climate,
         LocalizedTextDto BestTimeToVisit,
         LocalizedTextDto WhatToWear,
         LocalizedTextDto? Notes,
         string? LastUpdated
     ) : IRequest<ApiResponse<bool>>;
}
