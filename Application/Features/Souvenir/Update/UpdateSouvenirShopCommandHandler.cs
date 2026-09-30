using MediatR;
using Microsoft.AspNetCore.Http;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Interfaces;
using Tourism.Application.IUnitofwork;

namespace Tourism.Application.Features.Souvenir.Update
{
    public class UpdateSouvenirShopCommandHandler
         : IRequestHandler<UpdateSouvenirShopCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public UpdateSouvenirShopCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<bool>> Handle(
            UpdateSouvenirShopCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.SouvenirShops.GetByIdAsync(request.Id, cancellationToken);
                if (entity is null)
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "المتجر المراد تعديله غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                if (request.ImageFile != null && request.ImageFile.Length > 0)
                {
                    if (!string.IsNullOrWhiteSpace(entity.Image) && entity.Image.Contains("assets/images/"))
                    {
                        _fileStorage.DeleteFile(entity.Image);
                    }
                    entity.Image = await _fileStorage.SaveFileAsync(request.ImageFile, "souvenirs", cancellationToken);
                }
                else if (!string.IsNullOrWhiteSpace(request.ExistingImage))
                {
                    entity.Image = request.ExistingImage;
                }

                var currentImages = request.ExistingImages ?? new List<string>();
                var deletedImages = (entity.Images ?? new List<string>()).Except(currentImages).ToList();
                foreach (var del in deletedImages)
                {
                    if (del.Contains("assets/images/"))
                    {
                        _fileStorage.DeleteFile(del);
                    }
                }

                if (request.NewImagesFiles != null && request.NewImagesFiles.Any())
                {
                    var uploaded = await _fileStorage.SaveFilesAsync(request.NewImagesFiles, "souvenirs", cancellationToken);
                    currentImages.AddRange(uploaded);
                }
                entity.Images = currentImages;

                entity.Name = request.Name;
                entity.NameAr = request.NameAr;
                entity.Description = request.Description;
                entity.DescriptionAr = request.DescriptionAr;
                entity.Category = request.Category;
                entity.CategoryAr = request.CategoryAr;
                entity.Address = request.Address;
                entity.AddressAr = request.AddressAr;
                entity.Phone = request.Phone;
                entity.Email = request.Email;
                entity.Latitude = request.Latitude;
                entity.Longitude = request.Longitude;
                entity.DistanceKm = request.DistanceKm;
                entity.Rating = request.Rating;
                entity.ReviewCount = request.ReviewCount;
                entity.PriceRange = request.PriceRange;
                entity.OpeningHours = request.OpeningHours;
                entity.OpeningHoursAr = request.OpeningHoursAr;
                entity.IsFeatured = request.IsFeatured;
                entity.AcceptsCreditCard = request.AcceptsCreditCard;
                entity.HasDelivery = request.HasDelivery;
                entity.HasOnlineStore = request.HasOnlineStore;
                entity.Specialties = request.Specialties ?? new List<string>();
                entity.SpecialtiesAr = request.SpecialtiesAr ?? new List<string>();

                _unitOfWork.SouvenirShops.Update(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "تم تعديل بيانات المتجر بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = $"حدث خطأ أثناء تعديل المتجر: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}