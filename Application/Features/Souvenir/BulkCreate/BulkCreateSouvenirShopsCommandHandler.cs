using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities;

namespace Tourism.Application.Features.Souvenir.BulkCreate
{
    public class BulkCreateSouvenirShopsCommandHandler
            : IRequestHandler<BulkCreateSouvenirShopsCommand, ApiResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BulkCreateSouvenirShopsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<int>> Handle(
            BulkCreateSouvenirShopsCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (request.Shops == null || !request.Shops.Any())
                {
                    return new ApiResponse<int>
                    {
                        Success = false,
                        Data = 0,
                        Message = "قائمة المتاجر فارغة",
                        Code = StatusCodes.Status400BadRequest
                    };
                }

                var entities = request.Shops.Select(s => new SouvenirShop
                {
                    Id = string.IsNullOrWhiteSpace(s.Id) ? Guid.NewGuid().ToString() : s.Id,
                    Name = s.Name ?? string.Empty,
                    NameAr = s.NameAr ?? string.Empty,
                    Description = s.Description ?? string.Empty,
                    DescriptionAr = s.DescriptionAr ?? string.Empty,
                    Category = s.Category ?? string.Empty,
                    CategoryAr = s.CategoryAr ?? string.Empty,
                    Address = s.Address ?? string.Empty,
                    AddressAr = s.AddressAr ?? string.Empty,
                    Phone = s.Phone ?? string.Empty,
                    Email = s.Email,
                    Image = s.Image ?? string.Empty,
                    Images = s.Images ?? new List<string>(),
                    Latitude = s.Latitude,
                    Longitude = s.Longitude,
                    DistanceKm = s.DistanceKm,
                    Rating = s.Rating,
                    ReviewCount = s.ReviewCount,
                    PriceRange = s.PriceRange ?? "$$",
                    OpeningHours = s.OpeningHours ?? string.Empty,
                    OpeningHoursAr = s.OpeningHoursAr ?? string.Empty,
                    IsFeatured = s.IsFeatured,
                    AcceptsCreditCard = s.AcceptsCreditCard,
                    HasDelivery = s.HasDelivery,
                    HasOnlineStore = s.HasOnlineStore,
                    Specialties = s.Specialties ?? new List<string>(),
                    SpecialtiesAr = s.SpecialtiesAr ?? new List<string>()
                }).ToList();

                foreach (var entity in entities)
                {
                    await _unitOfWork.SouvenirShops.AddAsync(entity, cancellationToken);
                }

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<int>
                {
                    Success = true,
                    Data = entities.Count,
                    Message = $"تم إضافة {entities.Count} متجر بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Data = 0,
                    Message = $"حدث خطأ أثناء الإدخال الجماعي: {ex.InnerException?.Message ?? ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}