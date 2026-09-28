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

namespace Tourism.Application.Features.Souvenir.Create
{
    public class CreateSouvenirShopCommandHandler
         : IRequestHandler<CreateSouvenirShopCommand, ApiResponse<SouvenirShopDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public CreateSouvenirShopCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<SouvenirShopDto>> Handle(
            CreateSouvenirShopCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                string mainImage = request.Image ?? string.Empty;
                if (request.ImageFile != null && request.ImageFile.Length > 0)
                {
                    mainImage = await _fileStorage.SaveFileAsync(request.ImageFile, "souvenirs", cancellationToken);
                }

                var gallery = request.Images ?? new List<string>();
                if (request.ImagesFiles != null && request.ImagesFiles.Any())
                {
                    var uploaded = await _fileStorage.SaveFilesAsync(request.ImagesFiles, "souvenirs", cancellationToken);
                    gallery.AddRange(uploaded);
                }

                var entity = new SouvenirShop
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name,
                    NameAr = request.NameAr,
                    Description = request.Description,
                    DescriptionAr = request.DescriptionAr,
                    Category = request.Category,
                    CategoryAr = request.CategoryAr,
                    Address = request.Address,
                    AddressAr = request.AddressAr,
                    Phone = request.Phone,
                    Email = request.Email,
                    Image = mainImage,
                    Images = gallery,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    DistanceKm = request.DistanceKm,
                    Rating = request.Rating,
                    ReviewCount = request.ReviewCount,
                    PriceRange = request.PriceRange,
                    OpeningHours = request.OpeningHours,
                    OpeningHoursAr = request.OpeningHoursAr,
                    IsFeatured = request.IsFeatured,
                    AcceptsCreditCard = request.AcceptsCreditCard,
                    HasDelivery = request.HasDelivery,
                    HasOnlineStore = request.HasOnlineStore,
                    Specialties = request.Specialties ?? new List<string>(),
                    SpecialtiesAr = request.SpecialtiesAr ?? new List<string>()
                };

                await _unitOfWork.SouvenirShops.AddAsync(entity, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var dto = new SouvenirShopDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    NameAr = entity.NameAr,
                    Description = entity.Description,
                    DescriptionAr = entity.DescriptionAr,
                    Category = entity.Category,
                    CategoryAr = entity.CategoryAr,
                    Address = entity.Address,
                    AddressAr = entity.AddressAr,
                    Phone = entity.Phone,
                    Email = entity.Email,
                    Image = entity.Image,
                    Images = entity.Images,
                    Latitude = entity.Latitude,
                    Longitude = entity.Longitude,
                    DistanceKm = entity.DistanceKm,
                    Rating = entity.Rating,
                    ReviewCount = entity.ReviewCount,
                    PriceRange = entity.PriceRange,
                    OpeningHours = entity.OpeningHours,
                    OpeningHoursAr = entity.OpeningHoursAr,
                    IsFeatured = entity.IsFeatured,
                    AcceptsCreditCard = entity.AcceptsCreditCard,
                    HasDelivery = entity.HasDelivery,
                    HasOnlineStore = entity.HasOnlineStore,
                    Specialties = entity.Specialties ?? new List<string>(),
                    SpecialtiesAr = entity.SpecialtiesAr ?? new List<string>(),
                    Products = new List<SouvenirProductDto>()
                };

                return new ApiResponse<SouvenirShopDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم إضافة متجر الهدايا وحفظ الصور بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<SouvenirShopDto>
                {
                    Success = false,
                    Data = null,
                    Message = $"حدث خطأ أثناء إضافة المتجر: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}