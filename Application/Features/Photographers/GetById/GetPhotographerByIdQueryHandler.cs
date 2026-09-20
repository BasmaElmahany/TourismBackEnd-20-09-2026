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

namespace Tourism.Application.Features.Photographers.GetById
{
    public class GetPhotographerByIdQueryHandler
         : IRequestHandler<GetPhotographerByIdQuery, ApiResponse<PhotographerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPhotographerByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<PhotographerDto>> Handle(
            GetPhotographerByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var x = await _unitOfWork.Photographers.GetByIdAsync(request.Id, cancellationToken);

                if (x is null)
                {
                    return new ApiResponse<PhotographerDto>
                    {
                        Success = false,
                        Data = null,
                        Message = "المصور غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                var dto = new PhotographerDto
                {
                    Id = x.Id,
                    Name = new LocalizedTextDto { En = x.Name.En, Ar = x.Name.Ar },
                    Bio = x.Bio is null ? null : new LocalizedTextDto { En = x.Bio.En, Ar = x.Bio.Ar },
                    Specialties = x.Specialties,
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
                };

                return new ApiResponse<PhotographerDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم جلب بيانات المصور بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<PhotographerDto>
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