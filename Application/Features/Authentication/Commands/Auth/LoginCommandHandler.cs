using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.Interfaces;
using DTourism.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.Commands.Auth
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ApiResponse<AuthResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwt;

        public LoginCommandHandler(
            UserManager<ApplicationUser> userManager,
            IJwtTokenGenerator jwt)
        {
            _userManager = userManager;
            _jwt = jwt;
        }

        public async Task<ApiResponse<AuthResponse>> Handle(
      LoginCommand request,
      CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user == null)
                {
                    return new ApiResponse<AuthResponse>
                    {
                        Success = false,
                        Message = "خطأ في اسم المستخدم او الباسورد",
                        Code = StatusCodes.Status401Unauthorized
                    };
                }

                var valid = await _userManager.CheckPasswordAsync(user, request.Password);

                if (!valid)
                {
                    return new ApiResponse<AuthResponse>
                    {
                        Success = false,
                        Message = "خطأ في اسم المستخدم او الباسورد",
                        Code = StatusCodes.Status401Unauthorized
                    };
                }

                var token = await _jwt.GenerateToken(user);

                return new ApiResponse<AuthResponse>
                {
                    Success = true,
                    Data = new AuthResponse
                    {
                        FullName = user.FullName,
                        Email = user.Email!,
                        Token = token
                    },
                    Message = "تم تسجيل الدخول بنجاح",
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
