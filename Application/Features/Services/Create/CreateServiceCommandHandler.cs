using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.Interfaces;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities;

namespace Tourism.Application.Features.Services.Create
{
    public class CreateServiceCommandHandler
         : IRequestHandler<CreateServiceCommand, ApiResponse<ServiceItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public CreateServiceCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<ServiceItemDto>> Handle(
            CreateServiceCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // حفظ الصورة داخل wwwroot/assets/images/services
                string imagePath = request.Image ?? string.Empty;
                if (request.ImageFile != null && request.ImageFile.Length > 0)
                {
                    imagePath = await _fileStorage.SaveFileAsync(request.ImageFile, "services", cancellationToken);
                }

                var entity = new ServiceItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name,
                    NameAr = request.NameAr,
                    Type = request.Type,
                    TypeAr = request.TypeAr,
                    Description = request.Description,
                    DescriptionAr = request.DescriptionAr,
                    Address = request.Address,
                    AddressAr = request.AddressAr,
                    Phone = request.Phone,
                    Email = request.Email,
                    Image = imagePath,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    DistanceKm = request.DistanceKm,
                    Rating = request.Rating,
                    Is24h = request.Is24h,
                    IsEmergency = request.IsEmergency,
                    IsFeatured = request.IsFeatured,
                    Features = request.Features,
                    FeaturesAr = request.FeaturesAr,
                    CommentsCount = request.CommentsCount,
                    Specialty = request.Specialty,
                    SpecialtyAr = request.SpecialtyAr,
                    OpeningHours = request.OpeningHours is null ? null : new ServiceOpeningHours
                    {
                        En = request.OpeningHours.En is null ? new Dictionary<string, string>() : new Dictionary<string, string>
                        {
                            { "monday", request.OpeningHours.En.Monday },
                            { "tuesday", request.OpeningHours.En.Tuesday },
                            { "wednesday", request.OpeningHours.En.Wednesday },
                            { "thursday", request.OpeningHours.En.Thursday },
                            { "friday", request.OpeningHours.En.Friday },
                            { "saturday", request.OpeningHours.En.Saturday },
                            { "sunday", request.OpeningHours.En.Sunday }
                        },
                        Ar = request.OpeningHours.Ar ?? new Dictionary<string, string>()
                    },
                    HasDelivery = request.HasDelivery,
                    AcceptsInsurance = request.AcceptsInsurance
                };

                await _unitOfWork.Services.AddAsync(entity, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var dto = new ServiceItemDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    NameAr = entity.NameAr,
                    Type = entity.Type,
                    TypeAr = entity.TypeAr,
                    Description = entity.Description,
                    DescriptionAr = entity.DescriptionAr,
                    Address = entity.Address,
                    AddressAr = entity.AddressAr,
                    Phone = entity.Phone,
                    Email = entity.Email,
                    Image = entity.Image,
                    Latitude = entity.Latitude,
                    Longitude = entity.Longitude,
                    DistanceKm = entity.DistanceKm,
                    Rating = entity.Rating,
                    Is24h = entity.Is24h,
                    IsEmergency = entity.IsEmergency,
                    IsFeatured = entity.IsFeatured,
                    Features = entity.Features,
                    FeaturesAr = entity.FeaturesAr,
                    CommentsCount = entity.CommentsCount,
                    Specialty = entity.Specialty,
                    SpecialtyAr = entity.SpecialtyAr,
                    OpeningHours = request.OpeningHours,
                    HasDelivery = entity.HasDelivery,
                    AcceptsInsurance = entity.AcceptsInsurance
                };

                return new ApiResponse<ServiceItemDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم إضافة الخدمة وحفظ الصورة بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<ServiceItemDto>
                {
                    Success = false,
                    Data = null,
                    Message = $"حدث خطأ أثناء إضافة الخدمة: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
