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

namespace Tourism.Application.Features.Souvenir.Delete
{
    public class DeleteSouvenirShopCommandHandler
        : IRequestHandler<DeleteSouvenirShopCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public DeleteSouvenirShopCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<bool>> Handle(
            DeleteSouvenirShopCommand request,
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
                        Message = "المتجر المراد حذفه غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                if (!string.IsNullOrWhiteSpace(entity.Image) && entity.Image.Contains("assets/images/"))
                {
                    _fileStorage.DeleteFile(entity.Image);
                }

                if (entity.Images != null && entity.Images.Any())
                {
                    foreach (var img in entity.Images)
                    {
                        if (!string.IsNullOrWhiteSpace(img) && img.Contains("assets/images/"))
                        {
                            _fileStorage.DeleteFile(img);
                        }
                    }
                }

                _unitOfWork.SouvenirShops.Delete(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "تم حذف متجر الهدايا وصوره بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = $"حدث خطأ أثناء حذف المتجر: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}