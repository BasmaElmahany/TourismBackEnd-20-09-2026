using Tourism.Application.Interfaces;
using Tourism.Infrastructure.Persistence;

using Tourism.Infrastructure.Services;
using DTourism.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tourism.Infrastructure.Repositories;
using Tourism.Application.IUnitofwork;
using Tourism.Infrastructure.Repositories.UnitOfWork;



namespace Tourism.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options => { options.Password.RequiredLength = 6; options.Password.RequireDigit = true; options.Password.RequireUppercase = false; options.Password.RequireLowercase = false; options.Password.RequireNonAlphanumeric = false; })
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                    };
                });
            services.AddScoped<IFileStorageService, FileStorageService>();

            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddAuthorization(); services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>(); return services;

        }
    }
}