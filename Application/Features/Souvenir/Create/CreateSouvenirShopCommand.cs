using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.Souvenir.Create
{
    public record CreateSouvenirShopCommand(
         string Name,
         string NameAr,
         string Description,
         string DescriptionAr,
         string Category,
         string CategoryAr,
         string Address,
         string AddressAr,
         string Phone,
         string? Email,
         IFormFile? ImageFile,
         List<IFormFile>? ImagesFiles,
         string? Image,
         List<string>? Images,
         double Latitude,
         double Longitude,
         double? DistanceKm,
         double? Rating,
         int? ReviewCount,
         string PriceRange,
         string OpeningHours,
         string OpeningHoursAr,
         bool? IsFeatured,
         bool? AcceptsCreditCard,
         bool? HasDelivery,
         bool? HasOnlineStore,
         List<string>? Specialties,
         List<string>? SpecialtiesAr
     ) : IRequest<ApiResponse<SouvenirShopDto>>;
}
