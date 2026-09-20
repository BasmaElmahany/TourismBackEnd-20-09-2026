using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.Attractions.getById
{
    public record GetAttractionByIdQuery(string Id) : IRequest<ApiResponse<AttractionDto>>;
}
