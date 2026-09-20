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

namespace Tourism.Application.Features.Tourguide.GetAll
{
    public class GetAllTourGuidesQueryHandler
          : IRequestHandler<GetAllTourGuidesQuery, ApiResponse<List<TourGuideDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTourGuidesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<TourGuideDto>>> Handle(
            GetAllTourGuidesQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var tourGuides = await _unitOfWork.TourGuides.GetAllAsync(cancellationToken);

                var dtos = tourGuides.Select(x => new TourGuideDto
                {
                    Id = x.Id,
                    Name = new LocalizedTextDto { En = x.Name.En, Ar = x.Name.Ar },
                    Bio = x.Bio is null ? null : new LocalizedTextDto { En = x.Bio.En, Ar = x.Bio.Ar },
                    Languages = x.Languages ?? new List<object>(),
                    ImageUrl = x.ImageUrl,
                    Phone = x.Phone is null ? null : new LocalizedTextDto { En = x.Phone.En, Ar = x.Phone.Ar },
                    Email = x.Email is null ? null : new LocalizedTextDto { En = x.Email.En, Ar = x.Email.Ar },
                    Social = x.Social is null ? null : new SocialLinksDto
                    {
                        Facebook = x.Social.Facebook,
                        Instagram = x.Social.Instagram,
                        Twitter = x.Social.Twitter,
                        Tiktok = x.Social.Tiktok,
                        Youtube = x.Social.Youtube
                    },
                    Location = x.Location is null ? null : new LocationInfoDto
                    {
                        Latitude = x.Location.Latitude,
                        Longitude = x.Location.Longitude,
                        Address = x.Location.Address is null ? null : new LocalizedTextDto
                        {
                            En = x.Location.Address.En,
                            Ar = x.Location.Address.Ar
                        }
                    },
                    Rating = x.Rating
                }).ToList();

                return new ApiResponse<List<TourGuideDto>>
                {
                    Success = true,
                    Data = dtos,
                    Message = "تم جلب المرشدين السياحيين بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<List<TourGuideDto>>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ أثناء جلب المرشدين السياحيين",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
