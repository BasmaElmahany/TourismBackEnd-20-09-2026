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
using Tourism.Domain.Entities.Common;

namespace Tourism.Application.Features.BlogPosts.Update
{
    public class UpdateBlogPostCommandHandler
           : IRequestHandler<UpdateBlogPostCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public UpdateBlogPostCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<bool>> Handle(
            UpdateBlogPostCommand request,
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
                        Message = "المقال المراد تعديله غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                if (request.ImageFile != null && request.ImageFile.Length > 0)
                {
                    if (!string.IsNullOrWhiteSpace(entity.ImageUrl) && entity.ImageUrl.Contains("assets/images/"))
                    {
                        _fileStorage.DeleteFile(entity.ImageUrl);
                    }

                    entity.ImageUrl = await _fileStorage.SaveFileAsync(request.ImageFile, "", cancellationToken);
                }
                else if (!string.IsNullOrWhiteSpace(request.ExistingImageUrl))
                {
                    entity.ImageUrl = request.ExistingImageUrl;
                }

                entity.Title = new LocalizedText { En = request.Title.En, Ar = request.Title.Ar };
                entity.Content = new LocalizedText { En = request.Content.En, Ar = request.Content.Ar };
                entity.Excerpt = new LocalizedText { En = request.Excerpt.En, Ar = request.Excerpt.Ar };
                entity.Author = new LocalizedText { En = request.Author.En, Ar = request.Author.Ar };
                entity.PublishDate = request.PublishDate;
                entity.Category = new LocalizedText { En = request.Category.En, Ar = request.Category.Ar };
                entity.Tags = request.Tags ?? new List<List<object>>();
                entity.ReadTime = request.ReadTime;
                entity.Featured = request.Featured;

                _unitOfWork.BlogPosts.Update(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "تم تعديل المقال بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = $"حدث خطأ أثناء تعديل المقال: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}