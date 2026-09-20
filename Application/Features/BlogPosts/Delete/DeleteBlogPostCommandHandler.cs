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

namespace Tourism.Application.Features.BlogPosts.Delete
{
    public class DeleteBlogPostCommandHandler
          : IRequestHandler<DeleteBlogPostCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public DeleteBlogPostCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<bool>> Handle(
            DeleteBlogPostCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.BlogPosts.GetByIdAsync(request.Id, cancellationToken);

                if (entity is null)
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "المقال المراد حذفه غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                if (!string.IsNullOrWhiteSpace(entity.ImageUrl) && entity.ImageUrl.Contains("assets/images/"))
                {
                    _fileStorage.DeleteFile(entity.ImageUrl);
                }

                _unitOfWork.BlogPosts.Delete(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "تم حذف المقال وصورته بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = $"حدث خطأ أثناء حذف المقال: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}