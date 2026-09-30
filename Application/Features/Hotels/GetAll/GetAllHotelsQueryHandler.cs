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

namespace Tourism.Application.Features.Hotels.GetAll
{
    public class GetAllHotelsQueryHandler
        : IRequestHandler<GetAllHotelsQuery, ApiResponse<List<HotelDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllHotelsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<HotelDto>>> Handle(
            GetAllHotelsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var hotels = await _unitOfWork.Hotels.GetAllAsync(cancellationToken);
                var dtos = hotels.Select(x => new HotelDto
                {
                    Id = x.Id,
                    Name = x.Name != null
                        ? new LocalizedTextDto { En = x.Name.En, Ar = x.Name.Ar }
                        : new LocalizedTextDto { En = string.Empty, Ar = string.Empty },

                    // فحص null قبل القراءة
                    Description = x.Description != null
                        ? new LocalizedTextDto { En = x.Description.En, Ar = x.Description.Ar }
                        : null,

                    ImageUrl = x.ImageUrl ?? string.Empty,
                    ImageGallery = x.ImageGallery ?? new List<string>(),
                    Latitude = x.Latitude ?? 0,
                    Longitude = x.Longitude ?? 0,
                    Rating = x.Rating ?? 0,
                    ReviewCount = x.ReviewCount ?? 0,

                    // فحص null قبل القراءة
                    PriceRange = x.PriceRange != null
                        ? new LocalizedTextDto { En = x.PriceRange.En, Ar = x.PriceRange.Ar }
                        : null,

                    Amenities = x.Amenities?
                        .Where(a => a != null)
                        .Select(a => new LocalizedTextDto { En = a.En, Ar = a.Ar })
                        .ToList() ?? new List<LocalizedTextDto>(),

                    RoomTypes = x.RoomTypes?
                        .Where(r => r != null)
                        .Select(r => new LocalizedTextDto { En = r.En, Ar = r.Ar })
                        .ToList() ?? new List<LocalizedTextDto>(),

                    // فحص null قبل القراءة
                    ContactInfo = x.ContactInfo != null
                        ? new HotelContactInfoDto
                        {
                            Phone = x.ContactInfo.Phone,
                            Email = x.ContactInfo.Email,
                            Website = x.ContactInfo.Website
                        }
                        : null,

                    StarRating = x.StarRating ?? 0
                }).ToList();
                return new ApiResponse<List<HotelDto>>
                {
                    Success = true,
                    Data = dtos,
                    Message = "تم جلب الفنادق بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<List<HotelDto>>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ أثناء جلب الفنادق",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}