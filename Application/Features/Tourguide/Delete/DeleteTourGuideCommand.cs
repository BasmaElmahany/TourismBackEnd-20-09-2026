using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;

namespace Tourism.Application.Features.Tourguide.Delete
{
    public record DeleteTourGuideCommand(string Id) : IRequest<ApiResponse<bool>>;
}
