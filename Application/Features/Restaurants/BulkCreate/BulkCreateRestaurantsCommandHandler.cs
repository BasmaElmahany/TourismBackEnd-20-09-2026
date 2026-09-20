using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities.Common;
using Tourism.Domain.Entities;

namespace Tourism.Application.Features.Restaurants.BulkCreate
{
    public class BulkCreateRestaurantsCommandHandler
         : IRequestHandler<BulkCreateRestaurantsCommand, ApiResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BulkCreateRestaurantsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<int>> Handle(
            BulkCreateRestaurantsCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (request.Restaurants == null || !request.Restaurants.Any())
                {
                    return new ApiResponse<int>
                    {
                        Success = false,
                        Data = 0,
                        Message = "قائمة المطاعم فارغة",
                        Code = StatusCodes.Status400BadRequest
                    };
                }

                var entities = request.Restaurants.Select(item => new Restaurant
                {
                    Id = string.IsNullOrWhiteSpace(item.Id) ? Guid.NewGuid().ToString() : item.Id,
                    Name = new LocalizedText
                    {
                        En = item.Name?.En ?? string.Empty,
                        Ar = item.Name?.Ar ?? string.Empty
                    },
                    Description = new LocalizedText
                    {
                        En = item.Description?.En ?? string.Empty,
                        Ar = item.Description?.Ar ?? string.Empty
                    },
                    ImageUrl = item.ImageUrl ?? string.Empty,
                    ImageGallery = item.ImageGallery ?? new List<string>(),
                    Latitude = item.Latitude,
                    Longitude = item.Longitude,
                    Rating = item.Rating,
                    ReviewCount = item.ReviewCount,
                    CuisineType = new LocalizedText
                    {
                        En = item.CuisineType?.En ?? string.Empty,
                        Ar = item.CuisineType?.Ar ?? string.Empty
                    },
                    PriceRange = new LocalizedText
                    {
                        En = item.PriceRange?.En ?? string.Empty,
                        Ar = item.PriceRange?.Ar ?? string.Empty
                    },
                    OpeningHours = new LocalizedText
                    {
                        En = item.OpeningHours?.En ?? string.Empty,
                        Ar = item.OpeningHours?.Ar ?? string.Empty
                    },
                    Specialties = item.Specialties?.Select(s => new LocalizedText
                    {
                        En = s.En,
                        Ar = s.Ar
                    }).ToList() ?? new List<LocalizedText>(),
                    Center = item.Center == null ? null : new LocalizedText
                    {
                        En = item.Center.En,
                        Ar = item.Center.Ar
                    },
                    MenuUrl = item.MenuUrl?.ToString(),
                    ContactInfo = new RestaurantContactInfo
                    {
                        Phone = new LocalizedText
                        {
                            En = item.ContactInfo?.Phone?.En ?? string.Empty,
                            Ar = item.ContactInfo?.Phone?.Ar ?? string.Empty
                        },
                        Email = item.ContactInfo?.Email
                    },
                    Features = item.Features?.Select(f => new LocalizedText
                    {
                        En = f.En,
                        Ar = f.Ar
                    }).ToList() ?? new List<LocalizedText>()
                }).ToList();

                foreach (var entity in entities)
                {
                    await _unitOfWork.Restaurants.AddAsync(entity, cancellationToken);
                }

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<int>
                {
                    Success = true,
                    Data = entities.Count,
                    Message = $"تم إضافة {entities.Count} مطعماً بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Data = 0,
                    Message = $"حدث خطأ أثناء الإدخال الجماعي للمطاعم: {ex.InnerException?.Message ?? ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}