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

namespace Tourism.Application.Features.Hotels.GetById
{
    public class GetHotelByIdQueryHandler
         : IRequestHandler<GetHotelByIdQuery, ApiResponse<HotelDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetHotelByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<HotelDto>> Handle(
            GetHotelByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var x = await _unitOfWork.Hotels.GetByIdAsync(request.Id, cancellationToken);

                if (x is null)
                {
                    return new ApiResponse<HotelDto>
                    {
                        Success = false,
                        Data = null,
                        Message = "الفندق غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                var dto = new HotelDto
                {
                    Id = x.Id,
                    Name = new LocalizedTextDto { En = x.Name.En, Ar = x.Name.Ar },
                    Description = new LocalizedTextDto { En = x.Description.En, Ar = x.Description.Ar },
                    ImageUrl = x.ImageUrl,
                    ImageGallery = x.ImageGallery ?? new List<string>(),
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    Rating = x.Rating,
                    ReviewCount = x.ReviewCount,
                    PriceRange = new LocalizedTextDto { En = x.PriceRange.En, Ar = x.PriceRange.Ar },
                    Amenities = x.Amenities?.Select(a => new LocalizedTextDto { En = a.En, Ar = a.Ar }).ToList() ?? new List<LocalizedTextDto>(),
                    RoomTypes = x.RoomTypes?.Select(r => new LocalizedTextDto { En = r.En, Ar = r.Ar }).ToList() ?? new List<LocalizedTextDto>(),
                    ContactInfo = new HotelContactInfoDto
                    {
                        Phone = new LocalizedTextDto { En = x.ContactInfo.Phone.En, Ar = x.ContactInfo.Phone.Ar },
                        Email = new LocalizedTextDto { En = x.ContactInfo.Email.En, Ar = x.ContactInfo.Email.Ar },
                        Website = x.ContactInfo.Website is null ? null : new LocalizedTextDto { En = x.ContactInfo.Website.En, Ar = x.ContactInfo.Website.Ar }
                    },
                    StarRating = x.StarRating
                };

                return new ApiResponse<HotelDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم جلب بيانات الفندق بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<HotelDto>
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