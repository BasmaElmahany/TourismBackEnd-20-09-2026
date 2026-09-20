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

namespace Tourism.Application.Features.Restaurants.GetById
{
    public class GetRestaurantByIdQueryHandler
         : IRequestHandler<GetRestaurantByIdQuery, ApiResponse<RestaurantDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRestaurantByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<RestaurantDto>> Handle(
            GetRestaurantByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var x = await _unitOfWork.Restaurants.GetByIdAsync(request.Id, cancellationToken);

                if (x is null)
                {
                    return new ApiResponse<RestaurantDto>
                    {
                        Success = false,
                        Data = null,
                        Message = "المطعم غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                var dto = new RestaurantDto
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
                    CuisineType = new LocalizedTextDto { En = x.CuisineType.En, Ar = x.CuisineType.Ar },
                    PriceRange = new LocalizedTextDto { En = x.PriceRange.En, Ar = x.PriceRange.Ar },
                    OpeningHours = new LocalizedTextDto { En = x.OpeningHours.En, Ar = x.OpeningHours.Ar },
                    Specialties = x.Specialties?.Select(s => new LocalizedTextDto { En = s.En, Ar = s.Ar }).ToList() ?? new List<LocalizedTextDto>(),
                    Center = x.Center is null ? null : new LocalizedTextDto { En = x.Center.En, Ar = x.Center.Ar },
                    MenuUrl = x.MenuUrl,
                    ContactInfo = new RestaurantContactInfoDto
                    {
                        Phone = new LocalizedTextDto { En = x.ContactInfo.Phone.En, Ar = x.ContactInfo.Phone.Ar },
                        Email = x.ContactInfo.Email
                    },
                    Features = x.Features?.Select(f => new LocalizedTextDto { En = f.En, Ar = f.Ar }).ToList() ?? new List<LocalizedTextDto>()
                };

                return new ApiResponse<RestaurantDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم جلب بيانات المطعم بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<RestaurantDto>
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