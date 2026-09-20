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
using Tourism.Domain.Entities;

namespace Tourism.Application.Features.Souvenir.CreateSouvenirProduct
{
    public class CreateSouvenirProductCommandHandler
         : IRequestHandler<CreateSouvenirProductCommand, ApiResponse<SouvenirProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSouvenirProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<SouvenirProductDto>> Handle(
            CreateSouvenirProductCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var shop = await _unitOfWork.SouvenirShops.GetByIdAsync(request.ShopId, cancellationToken);
                if (shop is null)
                {
                    return new ApiResponse<SouvenirProductDto>
                    {
                        Success = false,
                        Data = null,
                        Message = "المتجر المحدد غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                var entity = new SouvenirProduct
                {
                    Id = Guid.NewGuid().ToString(),
                    ShopId = request.ShopId,
                    Name = request.Name,
                    NameAr = request.NameAr,
                    Description = request.Description,
                    DescriptionAr = request.DescriptionAr,
                    Category = request.Category,
                    CategoryAr = request.CategoryAr,
                    Price = request.Price,
                    Currency = request.Currency,
                    Image = request.Image,
                    Images = request.Images ?? new List<string>(),
                    InStock = request.InStock,
                    Handmade = request.Handmade,
                    Material = request.Material,
                    MaterialAr = request.MaterialAr,
                    Origin = request.Origin,
                    OriginAr = request.OriginAr
                };

                await _unitOfWork.SouvenirProducts.AddAsync(entity, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var dto = new SouvenirProductDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    NameAr = entity.NameAr,
                    Description = entity.Description,
                    DescriptionAr = entity.DescriptionAr,
                    Category = entity.Category,
                    CategoryAr = entity.CategoryAr,
                    Price = entity.Price,
                    Currency = entity.Currency,
                    Image = entity.Image,
                    Images = entity.Images,
                    InStock = entity.InStock,
                    Handmade = entity.Handmade,
                    Material = entity.Material,
                    MaterialAr = entity.MaterialAr,
                    Origin = entity.Origin,
                    OriginAr = entity.OriginAr
                };

                return new ApiResponse<SouvenirProductDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم إضافة المنتج بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch
            {
                return new ApiResponse<SouvenirProductDto>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ أثناء إضافة المنتج",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}