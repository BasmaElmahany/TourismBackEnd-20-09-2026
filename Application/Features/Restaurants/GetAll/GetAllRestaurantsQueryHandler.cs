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

namespace Tourism.Application.Features.Restaurants.GetAll
{
    public class GetAllRestaurantsQueryHandler
        : IRequestHandler<GetAllRestaurantsQuery, ApiResponse<List<RestaurantDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRestaurantsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<RestaurantDto>>> Handle(
            GetAllRestaurantsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var restaurants = await _unitOfWork.Restaurants.GetAllAsync(cancellationToken);

                var dtos = restaurants.Select(x => new RestaurantDto
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
                }).ToList();

                return new ApiResponse<List<RestaurantDto>>
                {
                    Success = true,
                    Data = dtos,
                    Message = "تم جلب المطاعم بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<List<RestaurantDto>>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ أثناء جلب المطاعم",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}