using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities;

namespace Tourism.Application.Features.Services.BulkCreate
{
    public class BulkCreateServicesCommandHandler
        : IRequestHandler<BulkCreateServicesCommand, ApiResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BulkCreateServicesCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<int>> Handle(
            BulkCreateServicesCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (request.Services == null || !request.Services.Any())
                {
                    return new ApiResponse<int>
                    {
                        Success = false,
                        Data = 0,
                        Message = "قائمة الخدمات فارغة",
                        Code = StatusCodes.Status400BadRequest
                    };
                }

                var entities = request.Services.Select(item => new ServiceItem
                {
                    Id = string.IsNullOrWhiteSpace(item.Id) ? Guid.NewGuid().ToString() : item.Id,
                    Name = item.Name ?? string.Empty,
                    NameAr = item.NameAr ?? string.Empty,
                    Type = item.Type ?? string.Empty,
                    TypeAr = item.TypeAr ?? string.Empty,
                    Description = item.Description ?? string.Empty,
                    DescriptionAr = item.DescriptionAr ?? string.Empty,
                    Address = item.Address ?? string.Empty,
                    AddressAr = item.AddressAr ?? string.Empty,
                    Phone = item.Phone ?? string.Empty,
                    Email = item.Email,
                    Image = item.Image ?? string.Empty,
                    Latitude = item.Latitude,
                    Longitude = item.Longitude,
                    DistanceKm = item.DistanceKm,
                    Rating = item.Rating,
                    Is24h = item.Is24h,
                    IsEmergency = item.IsEmergency,
                    IsFeatured = item.IsFeatured,
                    Features = item.Features ?? new List<string>(),
                    FeaturesAr = item.FeaturesAr ?? new List<string>(),
                    CommentsCount = item.CommentsCount,
                    Specialty = item.Specialty,
                    SpecialtyAr = item.SpecialtyAr,
                    OpeningHours = item.OpeningHours is null ? null : new ServiceOpeningHours
                    {
                        En = item.OpeningHours.En is null ? new Dictionary<string, string>() : new Dictionary<string, string>
                        {
                            { "monday", item.OpeningHours.En.Monday ?? string.Empty },
                            { "tuesday", item.OpeningHours.En.Tuesday ?? string.Empty },
                            { "wednesday", item.OpeningHours.En.Wednesday ?? string.Empty },
                            { "thursday", item.OpeningHours.En.Thursday ?? string.Empty },
                            { "friday", item.OpeningHours.En.Friday ?? string.Empty },
                            { "saturday", item.OpeningHours.En.Saturday ?? string.Empty },
                            { "sunday", item.OpeningHours.En.Sunday ?? string.Empty }
                        },
                        Ar = item.OpeningHours.Ar ?? new Dictionary<string, string>()
                    },
                    HasDelivery = item.HasDelivery,
                    AcceptsInsurance = item.AcceptsInsurance
                }).ToList();

                foreach (var entity in entities)
                {
                    await _unitOfWork.Services.AddAsync(entity, cancellationToken);
                }

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<int>
                {
                    Success = true,
                    Data = entities.Count,
                    Message = $"تم إضافة {entities.Count} خدمة بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Data = 0,
                    Message = $"حدث خطأ أثناء الإدخال الجماعي للخدمات: {ex.InnerException?.Message ?? ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}