using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities.Common;
using Tourism.Domain.Entities;

namespace Tourism.Application.Features.Hotels.BulkCreate
{
    public class BulkCreateHotelsCommandHandler
         : IRequestHandler<BulkCreateHotelsCommand, ApiResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BulkCreateHotelsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<int>> Handle(
            BulkCreateHotelsCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (request.Hotels == null || !request.Hotels.Any())
                {
                    return new ApiResponse<int>
                    {
                        Success = false,
                        Data = 0,
                        Message = "قائمة الفنادق فارغة",
                        Code = StatusCodes.Status400BadRequest
                    };
                }

                var entities = request.Hotels.Select(item => new Hotel
                {
                    Id = string.IsNullOrWhiteSpace(item.Id) ? Guid.NewGuid().ToString() : item.Id,
                    Name = new LocalizedText { En = item.Name.En, Ar = item.Name.Ar },
                    Description = new LocalizedText { En = item.Description.En, Ar = item.Description.Ar },
                    ImageUrl = item.ImageUrl,
                    ImageGallery = item.ImageGallery ?? new List<string>(),
                    Latitude = item.Latitude,
                    Longitude = item.Longitude,
                    Rating = item.Rating,
                    ReviewCount = item.ReviewCount,
                    PriceRange = new LocalizedText { En = item.PriceRange.En, Ar = item.PriceRange.Ar },
                    Amenities = item.Amenities?.Select(a => new LocalizedText { En = a.En, Ar = a.Ar }).ToList() ?? new List<LocalizedText>(),
                    RoomTypes = item.RoomTypes?.Select(r => new LocalizedText { En = r.En, Ar = r.Ar }).ToList() ?? new List<LocalizedText>(),
                    ContactInfo = new HotelContactInfo
                    {
                        Phone = item.ContactInfo.Phone,
                        Email = item.ContactInfo.Email,
                        Website = item.ContactInfo.Website is null ? null : item.ContactInfo.Website
                            },
                    StarRating = item.StarRating
                }).ToList();

                foreach (var entity in entities)
                {
                    await _unitOfWork.Hotels.AddAsync(entity, cancellationToken);
                }

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<int>
                {
                    Success = true,
                    Data = entities.Count,
                    Message = $"تم إدخال {entities.Count} فندقاً بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Data = 0,
                    Message = $"حدث خطأ أثناء الإدخال الجماعي للفنادق: {ex.InnerException?.Message ?? ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}

