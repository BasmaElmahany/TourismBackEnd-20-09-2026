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

namespace Tourism.Application.Features.Souvenir.GetProductsByShopId
{
    public class GetProductsByShopIdQueryHandler
           : IRequestHandler<GetProductsByShopIdQuery, ApiResponse<List<SouvenirProductDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductsByShopIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<SouvenirProductDto>>> Handle(
            GetProductsByShopIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var products = await _unitOfWork.SouvenirProducts.FindAsync(p => p.ShopId == request.ShopId, cancellationToken);

                var dtos = products.Select(p => new SouvenirProductDto
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
                    Images = p.Images ?? new List<string>(),
                    InStock = p.InStock,
                    Handmade = p.Handmade,
                    Material = p.Material,
                    MaterialAr = p.MaterialAr,
                    Origin = p.Origin,
                    OriginAr = p.OriginAr
                }).ToList();

                return new ApiResponse<List<SouvenirProductDto>>
                {
                    Success = true,
                    Data = dtos,
                    Message = "تم جلب منتجات المتجر بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<List<SouvenirProductDto>>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ أثناء جلب المنتجات",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}