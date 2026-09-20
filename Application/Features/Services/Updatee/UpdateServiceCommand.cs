using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.Services.Updatee
{
    public record UpdateServiceCommand(
         string Id,
         string Name,
         string NameAr,
         string Type,
         string TypeAr,
         string Description,
         string DescriptionAr,
         string Address,
         string AddressAr,
         string Phone,
         string? Email,
         IFormFile? ImageFile,              // ملف صورة جديد اختياري
         string? ExistingImage,             // المسار القديم إن لم يُرفع ملف جديد
         double? Latitude,
         double? Longitude,
         double? DistanceKm,
         double? Rating,
         bool? Is24h,
         bool? IsEmergency,
         bool? IsFeatured,
         List<string>? Features,
         List<string>? FeaturesAr,
         int? CommentsCount,
         string? Specialty,
         string? SpecialtyAr,
         ServiceOpeningHoursDto? OpeningHours,
         bool? HasDelivery,
         bool? AcceptsInsurance
     ) : IRequest<ApiResponse<bool>>;
}

