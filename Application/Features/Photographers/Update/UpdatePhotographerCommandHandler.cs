using MediatR;
using Microsoft.AspNetCore.Http;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Interfaces;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities.Common;

namespace Tourism.Application.Features.Photographers.Update
{
    public class UpdatePhotographerCommandHandler
         : IRequestHandler<UpdatePhotographerCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public UpdatePhotographerCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<bool>> Handle(
            UpdatePhotographerCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.Photographers.GetByIdAsync(request.Id, cancellationToken);

                if (entity is null)
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "المصور المراد تعديله غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                // Handle image update
                if (request.ImageFile != null && request.ImageFile.Length > 0)
                {
                    // Clean up previous file if it was locally hosted
                    if (!string.IsNullOrWhiteSpace(entity.ImageUrl) && entity.ImageUrl.StartsWith("/assets/images/"))
                    {
                        _fileStorage.DeleteFile(entity.ImageUrl);
                    }

                    entity.ImageUrl = await _fileStorage.SaveFileAsync(request.ImageFile, "photographers", cancellationToken);
                }
                else if (!string.IsNullOrWhiteSpace(request.ExistingImageUrl))
                {
                    entity.ImageUrl = request.ExistingImageUrl;
                }

                entity.Name = new LocalizedText { En = request.Name.En, Ar = request.Name.Ar };
                entity.Bio = request.Bio is null ? null : new LocalizedText { En = request.Bio.En, Ar = request.Bio.Ar };
                entity.Specialties = request.Specialties;
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

                _unitOfWork.Photographers.Update(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "تم تعديل بيانات المصور بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = $"حدث خطأ أثناء تعديل بيانات المصور: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}