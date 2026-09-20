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
using Tourism.Domain.Entities.Common;
using Tourism.Domain.Entities;

namespace Tourism.Application.Features.Tourguide.Create
{
    public class CreateTourGuideCommandHandler
        : IRequestHandler<CreateTourGuideCommand, ApiResponse<TourGuideDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTourGuideCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<TourGuideDto>> Handle(
            CreateTourGuideCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var entity = new TourGuide
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = new LocalizedText { En = request.Name.En, Ar = request.Name.Ar },
                    Bio = request.Bio is null ? null : new LocalizedText { En = request.Bio.En, Ar = request.Bio.Ar },
                    Languages = request.Languages ?? new List<object>(),
                    ImageUrl = request.ImageUrl,
                    Phone = request.Phone is null ? null : new LocalizedText { En = request.Phone.En, Ar = request.Phone.Ar },
                    Email = request.Email is null ? null : new LocalizedText { En = request.Email.En, Ar = request.Email.Ar },
                    Social = request.Social is null ? null : new SocialLinks
                    {
                        Facebook = request.Social.Facebook,
                        Instagram = request.Social.Instagram,
                        Twitter = request.Social.Twitter,
                        Tiktok = request.Social.Tiktok,
                        Youtube = request.Social.Youtube
                    },
                    Location = request.Location is null ? null : new LocationInfo
                    {
                        Latitude = request.Location.Latitude,
                        Longitude = request.Location.Longitude,
                        Address = request.Location.Address is null ? null : new LocalizedText
                        {
                            En = request.Location.Address.En,
                            Ar = request.Location.Address.Ar
                        }
                    },
                    Rating = request.Rating
                };

                await _unitOfWork.TourGuides.AddAsync(entity, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var dto = new TourGuideDto
                {
                    Id = entity.Id,
                    Name = request.Name,
                    Bio = request.Bio,
                    Languages = entity.Languages,
                    ImageUrl = entity.ImageUrl,
                    Phone = request.Phone,
                    Email = request.Email,
                    Social = request.Social,
                    Location = request.Location,
                    Rating = entity.Rating
                };

                return new ApiResponse<TourGuideDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم إضافة المرشد السياحي بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch
            {
                return new ApiResponse<TourGuideDto>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ أثناء إضافة المرشد السياحي",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}