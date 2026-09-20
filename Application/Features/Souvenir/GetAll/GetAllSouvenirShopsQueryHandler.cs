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

namespace Tourism.Application.Features.Souvenir.GetAll
{
    public class GetAllSouvenirShopsQueryHandler
        : IRequestHandler<GetAllSouvenirShopsQuery, ApiResponse<List<SouvenirShopDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSouvenirShopsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<SouvenirShopDto>>> Handle(
            GetAllSouvenirShopsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var shops = await _unitOfWork.SouvenirShops.GetAllAsync(cancellationToken);

                var dtos = shops.Select(x => new SouvenirShopDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    NameAr = x.NameAr,
                    Description = x.Description,
                    DescriptionAr = x.DescriptionAr,
                    Category = x.Category,
                    CategoryAr = x.CategoryAr,
                    Address = x.Address,
                    AddressAr = x.AddressAr,
                    Phone = x.Phone,
                    Email = x.Email,
                    Image = x.Image,
                    Images = x.Images ?? new List<string>(),
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    DistanceKm = x.DistanceKm,
                    Rating = x.Rating,
                    ReviewCount = x.ReviewCount,
                    PriceRange = x.PriceRange,
                    OpeningHours = x.OpeningHours,
                    OpeningHoursAr = x.OpeningHoursAr,
                    IsFeatured = x.IsFeatured,
                    AcceptsCreditCard = x.AcceptsCreditCard,
                    HasDelivery = x.HasDelivery,
                    HasOnlineStore = x.HasOnlineStore,
                    Specialties = x.Specialties ?? new List<string>(),
                    SpecialtiesAr = x.SpecialtiesAr ?? new List<string>()
                }).ToList();

                return new ApiResponse<List<SouvenirShopDto>>
                {
                    Success = true,
                    Data = dtos,
                    Message = "تم جلب متاجر الهدايا بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<List<SouvenirShopDto>>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ أثناء جلب المتاجر",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}