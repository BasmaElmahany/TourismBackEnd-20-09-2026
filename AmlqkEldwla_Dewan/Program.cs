
using Tourism.Application.DependencyInjection;
using Tourism.Application.Interfaces;
using Tourism.Infrastructure.DependencyInjection;
using Tourism.Infrastructure.Persistence;
using DTourism.Domain.Entities;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Tourism
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp", policy =>
                {
                    policy
                        .WithOrigins(
                            "http://localhost:4200",
                            "https://localhost:4200",
                            "http://172.36.1.161:1067",
                            "http://172.36.1.161"
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

          
            builder.Services.AddSwaggerGen(options =>
            {
                // JWT Authentication
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter: Bearer {your JWT token}"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

                // XML Documentation
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                if (File.Exists(xmlPath))
                {
                    options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
                }
            });

            // Register Application Layer (MediatR, FluentValidation, Behaviors...)
            builder.Services.AddApplication();

            // Register Infrastructure Layer
            builder.Services.AddInfrastructure(builder.Configuration);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            

            var app = builder.Build();

            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
           
            app.UseHttpsRedirection();
            app.UseCors("AllowAngularApp");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
         
            app.MapControllers();

            app.Run();
        }
    }
}
