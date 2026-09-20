using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.Photographers.GetAll
{
    public record GetAllPhotographersQuery : IRequest<ApiResponse<List<PhotographerDto>>>;
}
