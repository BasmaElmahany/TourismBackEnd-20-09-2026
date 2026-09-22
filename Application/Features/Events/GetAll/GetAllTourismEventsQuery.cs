using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.DTOs;

namespace Tourism.Application.Features.Events.GetAll
{
    public record GetAllTourismEventsQuery() : IRequest<ApiResponse<List<TourismEventDto>>>;
}
