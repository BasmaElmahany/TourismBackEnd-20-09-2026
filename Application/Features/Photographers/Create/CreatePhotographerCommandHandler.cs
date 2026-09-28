using MediatR;
using Microsoft.AspNetCore.Http;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.Interfaces;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities;
using Tourism.Domain.Entities.Common;

namespace Tourism.Application.Features.Photographers.Create
{
    public class CreatePhotographerCommandHandler
        : IRequestHandler<CreatePhotographerCommand, ApiResponse<PhotographerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public CreatePhotographerCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<PhotographerDto>> Handle(
            CreatePhotographerCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // حفظ صورة المصور
                string imageUrl = string.Empty;
                if (request.ImageFile != null)
                {
                    imageUrl = await _fileStorage.SaveFileAsync(request.ImageFile, "photographers", cancellationToken);
                }

                var entity = new Photographer
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = new LocalizedText { En = request.Name.En, Ar = request.Name.Ar },
                    Bio = request.Bio is null ? null : new LocalizedText { En = request.Bio.En, Ar = request.Bio.Ar },
                    Specialties = request.Specialties,
                    ImageUrl = imageUrl,
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

                await _unitOfWork.Photographers.AddAsync(entity, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var dto = new PhotographerDto
                {
                    Id = entity.Id,
                    Name = request.Name,
                    Bio = request.Bio,
                    Specialties = entity.Specialties,
                    ImageUrl = entity.ImageUrl,
                    Phone = request.Phone,
                    Email = request.Email,
                    Social = request.Social,
                    Location = request.Location,
                    Rating = entity.Rating
                };

                return new ApiResponse<PhotographerDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم إضافة المصور وحفظ الصورة بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch
            {
                return new ApiResponse<PhotographerDto>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ أثناء إضافة المصور",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}