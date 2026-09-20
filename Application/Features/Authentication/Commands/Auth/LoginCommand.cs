using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using MediatR;




namespace Tourism.Application.Features.Authentication.Commands.Auth
{
    public record LoginCommand(
        string UserName,
        string Password
    ) : IRequest<ApiResponse<AuthResponse>>;
}
