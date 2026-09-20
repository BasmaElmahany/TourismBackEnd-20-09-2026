using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Interfaces;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities;

namespace Tourism.Application.Features.Services.Updatee
{
    public class UpdateServiceCommandHandler
          : IRequestHandler<UpdateServiceCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public UpdateServiceCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<bool>> Handle(
            UpdateServiceCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.Services.GetByIdAsync(request.Id, cancellationToken);

                if (entity is null)
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "الخدمة المراد تعديلها غير موجودة",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                // استبدال الصورة القديمة وحذفها من wwwroot إذا رُفع ملف جديد
                if (request.ImageFile != null && request.ImageFile.Length > 0)
                {
                    if (!string.IsNullOrWhiteSpace(entity.Image) && entity.Image.StartsWith("/assets/images/"))
                    {
                        _fileStorage.DeleteFile(entity.Image);
                    }

                    entity.Image = await _fileStorage.SaveFileAsync(request.ImageFile, "services", cancellationToken);
                }
                else if (!string.IsNullOrWhiteSpace(request.ExistingImage))
                {
                    entity.Image = request.ExistingImage;
                }

                entity.Name = request.Name;
                entity.NameAr = request.NameAr;
                entity.Type = request.Type;
                entity.TypeAr = request.TypeAr;
                entity.Description = request.Description;
                entity.DescriptionAr = request.DescriptionAr;
                entity.Address = request.Address;
                entity.AddressAr = request.AddressAr;
                entity.Phone = request.Phone;
                entity.Email = request.Email;
                entity.Latitude = request.Latitude;
                entity.Longitude = request.Longitude;
                entity.DistanceKm = request.DistanceKm;
                entity.Rating = request.Rating;
                entity.Is24h = request.Is24h;
                entity.IsEmergency = request.IsEmergency;
                entity.IsFeatured = request.IsFeatured;
                entity.Features = request.Features;
                entity.FeaturesAr = request.FeaturesAr;
                entity.CommentsCount = request.CommentsCount;
                entity.Specialty = request.Specialty;
                entity.SpecialtyAr = request.SpecialtyAr;
                entity.OpeningHours = request.OpeningHours is null ? null : new ServiceOpeningHours
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
                };
                entity.HasDelivery = request.HasDelivery;
                entity.AcceptsInsurance = request.AcceptsInsurance;

                _unitOfWork.Services.Update(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "تم تعديل بيانات الخدمة والصورة بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = $"حدث خطأ أثناء تعديل بيانات الخدمة: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }

}