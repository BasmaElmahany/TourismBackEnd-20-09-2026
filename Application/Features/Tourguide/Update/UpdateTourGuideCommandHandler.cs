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

namespace Tourism.Application.Features.Tourguide.Update
{
    public class UpdateTourGuideCommandHandler
            : IRequestHandler<UpdateTourGuideCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTourGuideCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<bool>> Handle(
            UpdateTourGuideCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.TourGuides.GetByIdAsync(request.Id, cancellationToken);

                if (entity is null)
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "المرشد السياحي المراد تعديله غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                entity.Name = new LocalizedText { En = request.Name.En, Ar = request.Name.Ar };
                entity.Bio = request.Bio is null ? null : new LocalizedText { En = request.Bio.En, Ar = request.Bio.Ar };
                entity.Languages = request.Languages ?? new List<object>();
                entity.ImageUrl = request.ImageUrl;
                entity.Phone = request.Phone is null ? null : new LocalizedText { En = request.Phone.En, Ar = request.Phone.Ar };
                entity.Email = request.Email is null ? null : new LocalizedText { En = request.Email.En, Ar = request.Email.Ar };
                entity.Social = request.Social is null ? null : new SocialLinks
                {
                    Facebook = request.Social.Facebook,
                    Instagram = request.Social.Instagram,
                    Twitter = request.Social.Twitter,
                    Tiktok = request.Social.Tiktok,
                    Youtube = request.Social.Youtube
                };
                entity.Location = request.Location is null ? null : new LocationInfo
                {
                    Latitude = request.Location.Latitude,
                    Longitude = request.Location.Longitude,
                    Address = request.Location.Address is null ? null : new LocalizedText
                    {
                        En = request.Location.Address.En,
                        Ar = request.Location.Address.Ar
                    }
                };
                entity.Rating = request.Rating;

                _unitOfWork.TourGuides.Update(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "تم تعديل بيانات المرشد السياحي بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "حدث خطأ أثناء تعديل بيانات المرشد السياحي",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}