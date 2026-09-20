using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.Commands.Auth
{
    public record RegisterCommand(
     string FullName,
     string UserName,
     string Email,
     string Password
 ) : IRequest<ApiResponse<AuthResponse>>;
}
