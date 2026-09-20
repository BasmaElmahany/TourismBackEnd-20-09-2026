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

namespace Tourism.Application.Features.Hotels.Delete
{
    public class DeleteHotelCommandHandler
          : IRequestHandler<DeleteHotelCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public DeleteHotelCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<bool>> Handle(
            DeleteHotelCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.Hotels.GetByIdAsync(request.Id, cancellationToken);

                if (entity is null)
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "الفندق المراد حذفه غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                // 1. حذف الصورة الرئيسية من wwwroot
                if (!string.IsNullOrWhiteSpace(entity.ImageUrl) && entity.ImageUrl.StartsWith("/assets/images/"))
                {
                    _fileStorage.DeleteFile(entity.ImageUrl);
                }

                // 2. حذف صور المعرض من wwwroot
                if (entity.ImageGallery != null && entity.ImageGallery.Any())
                {
                    foreach (var img in entity.ImageGallery)
                    {
                        if (!string.IsNullOrWhiteSpace(img) && img.StartsWith("/assets/images/"))
                        {
                            _fileStorage.DeleteFile(img);
                        }
                    }
                }

                // 3. حذف السجل من قاعدة البيانات
                _unitOfWork.Hotels.Delete(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "تم حذف الفندق وجميع صوره بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = $"حدث خطأ أثناء حذف الفندق: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}