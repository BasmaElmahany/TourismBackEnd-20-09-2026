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

namespace Tourism.Application.Features.Souvenir.GetById
{
    public class GetSouvenirShopByIdQueryHandler
         : IRequestHandler<GetSouvenirShopByIdQuery, ApiResponse<SouvenirShopDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSouvenirShopByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<SouvenirShopDto>> Handle(
            GetSouvenirShopByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var x = await _unitOfWork.SouvenirShops.GetByIdAsync(request.Id, cancellationToken);

                if (x is null)
                {
                    return new ApiResponse<SouvenirShopDto>
                    {
                        Success = false,
                        Data = null,
                        Message = "المتجر غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                var products = await _unitOfWork.SouvenirProducts.FindAsync(p => p.ShopId == x.Id, cancellationToken);

                var dto = new SouvenirShopDto
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
                    SpecialtiesAr = x.SpecialtiesAr ?? new List<string>(),
                    Products = products.Select(p => new SouvenirProductDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        NameAr = p.NameAr,
                        Description = p.Description,
                        DescriptionAr = p.DescriptionAr,
                        Category = p.Category,
                        CategoryAr = p.CategoryAr,
                        Price = p.Price,
                        Currency = p.Currency,
                        Image = p.Image,
                        Images = p.Images,
                        InStock = p.InStock,
                        Handmade = p.Handmade,
                        Material = p.Material,
                        MaterialAr = p.MaterialAr,
                        Origin = p.Origin,
                        OriginAr = p.OriginAr
                    }).ToList()
                };

                return new ApiResponse<SouvenirShopDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم جلب بيانات المتجر بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<SouvenirShopDto>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ غير متوقع",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}