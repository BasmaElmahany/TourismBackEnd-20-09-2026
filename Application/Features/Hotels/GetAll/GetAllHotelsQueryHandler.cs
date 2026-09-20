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