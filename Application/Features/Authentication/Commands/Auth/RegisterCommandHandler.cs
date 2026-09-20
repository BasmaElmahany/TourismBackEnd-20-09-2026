using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.Interfaces;
using DTourism.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Tourism.Application.Features.Authentication.Commands.Auth;


namespace Tourism.Application.Features.Authentication.Commands.Auth
{
    public class RegisterCommandHandler
     : IRequestHandler<RegisterCommand, ApiResponse<AuthResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IJwtTokenGenerator _jwt;

        public RegisterCommandHandler(
            UserManager<ApplicationUser> userManager,
            IJwtTokenGenerator jwt)
        {
            _userManager = userManager;
            _jwt = jwt;
        }

        public async Task<ApiResponse<AuthResponse>> Handle(
            RegisterCommand request,
            CancellationToken cancellationToken)
        {
          try {
                var user = new ApplicationUser
                {
                    FullName = request.FullName,
                    UserName = request.UserName,
                    Email = request.Email
                };

                var result = await _userManager.CreateAsync(
                    user,
                    request.Password);

                if (!result.Succeeded)
                    throw new Exception(result.Errors.First().Description);

                var token = await _jwt.GenerateToken(user);

                return new ApiResponse<AuthResponse>
                {
                    Success = true,
                    Data = new AuthResponse
                    {

                        Email = user.Email!,
                        FullName = user.FullName,
                        Token = token

                    },
                    Message = "تم إنشاء المستخدم بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<AuthResponse>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ غير متوقع",
                    Code = StatusCodes.Status500InternalServerError
                };
            }

        }
    }
}
