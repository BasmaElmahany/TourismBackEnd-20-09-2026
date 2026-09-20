using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.IUnitofwork;

namespace Tourism.Application.Features.Services.GetAll
{
    public class GetAllServicesQueryHandler
          : IRequestHandler<GetAllServicesQuery, ApiResponse<List<ServiceItemDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllServicesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<ServiceItemDto>>> Handle(
            GetAllServicesQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var services = await _unitOfWork.Services.GetAllAsync(cancellationToken);

                var dtos = services.Select(x => new ServiceItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    NameAr = x.NameAr,
                    Type = x.Type,
                    TypeAr = x.TypeAr,
                    Description = x.Description,
                    DescriptionAr = x.DescriptionAr,
                    Address = x.Address,
                    AddressAr = x.AddressAr,
                    Phone = x.Phone,
                    Email = x.Email,
                    Image = x.Image,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    DistanceKm = x.DistanceKm,
                    Rating = x.Rating,
                    Is24h = x.Is24h,
                    IsEmergency = x.IsEmergency,
                    IsFeatured = x.IsFeatured,
                    Features = x.Features,
                    FeaturesAr = x.FeaturesAr,
                    CommentsCount = x.CommentsCount,
                    Specialty = x.Specialty,
                    SpecialtyAr = x.SpecialtyAr,
                    OpeningHours = x.OpeningHours is null ? null : new ServiceOpeningHoursDto
                    {
                        En = new ServiceWeeklyScheduleDto
                        {
                            Monday = x.OpeningHours.En.GetValueOrDefault("monday", string.Empty),
                            Tuesday = x.OpeningHours.En.GetValueOrDefault("tuesday", string.Empty),
                            Wednesday = x.OpeningHours.En.GetValueOrDefault("wednesday", string.Empty),
                            Thursday = x.OpeningHours.En.GetValueOrDefault("thursday", string.Empty),
                            Friday = x.OpeningHours.En.GetValueOrDefault("friday", string.Empty),
                            Saturday = x.OpeningHours.En.GetValueOrDefault("saturday", string.Empty),
                            Sunday = x.OpeningHours.En.GetValueOrDefault("sunday", string.Empty)
                        },
                        Ar = x.OpeningHours.Ar ?? new Dictionary<string, string>()
                    },
                    HasDelivery = x.HasDelivery,
                    AcceptsInsurance = x.AcceptsInsurance
                }).ToList();

                return new ApiResponse<List<ServiceItemDto>>
                {
                    Success = true,
                    Data = dtos,
                    Message = "تم جلب الخدمات بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<List<ServiceItemDto>>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ أثناء جلب الخدمات",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}