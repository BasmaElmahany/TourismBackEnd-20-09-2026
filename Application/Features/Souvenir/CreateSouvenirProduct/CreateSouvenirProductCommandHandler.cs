using MediatR;
using Microsoft.AspNetCore.Http;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.Interfaces;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities;

namespace Tourism.Application.Features.Souvenir.CreateSouvenirProduct
{
    public class CreateSouvenirProductCommandHandler
         : IRequestHandler<CreateSouvenirProductCommand, ApiResponse<SouvenirProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public CreateSouvenirProductCommandHandler(IUnitOfWork unitOfWork,
                                                   IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<SouvenirProductDto>> Handle(
            CreateSouvenirProductCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (request.Price < 0)
                {
                    return new ApiResponse<SouvenirProductDto>
                    {
                        Success = false,
                        Data = null,
                        Message = "السعر لا يمكن أن يكون سالبًا",
                        Code = StatusCodes.Status400BadRequest
                    };
                }

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

                string mainImage = request.Image ?? string.Empty;
                if (request.ImageFile != null && request.ImageFile.Length > 0)
                {
                    mainImage = await _fileStorage.SaveFileAsync(request.ImageFile, "souvenirs", cancellationToken);
                }

                var gallery = new List<string>(request.Images ?? new List<string>());
                if (request.ImagesFiles != null && request.ImagesFiles.Any())
                {
                    var uploaded = await _fileStorage.SaveFilesAsync(request.ImagesFiles, "souvenirs", cancellationToken);
                    gallery.AddRange(uploaded);
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
                    Image = mainImage,
                    Images = gallery,
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
            catch (Exception ex)
            {
                return new ApiResponse<SouvenirProductDto>
                {
                    Success = false,
                    Data = null,
                    Message = $"حدث خطأ أثناء إضافة المنتج: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}