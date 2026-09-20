using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Interfaces;
using Tourism.Application.IUnitofwork;

namespace Tourism.Application.Features.Attractions.Delete
{
    public class DeleteAttractionCommandHandler
             : IRequestHandler<DeleteAttractionCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public DeleteAttractionCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<bool>> Handle(
            DeleteAttractionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.Attractions.GetByIdAsync(request.Id, cancellationToken);

                if (entity is null)
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "المعلم السياحي المراد حذفه غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                // 1. Delete main image file from wwwroot
                if (!string.IsNullOrWhiteSpace(entity.ImageUrl) && entity.ImageUrl.StartsWith("/assets/images/"))
                {
                    _fileStorage.DeleteFile(entity.ImageUrl);
                }

                // 2. Delete all gallery files from wwwroot
                if (entity.ImageGallery != null && entity.ImageGallery.Any())
                {
                    foreach (var imagePath in entity.ImageGallery)
                    {
                        if (!string.IsNullOrWhiteSpace(imagePath) && imagePath.StartsWith("/assets/images/"))
                        {
                            _fileStorage.DeleteFile(imagePath);
                        }
                    }
                }

                // 3. Remove entity from database
                _unitOfWork.Attractions.Delete(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "تم حذف المعلم السياحي والصور المرتبطة به بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = $"حدث خطأ أثناء حذف المعلم السياحي: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
