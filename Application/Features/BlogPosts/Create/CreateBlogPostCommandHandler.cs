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
using Tourism.Application.Interfaces;

namespace Tourism.Application.Features.BlogPosts.Create
{


    public class CreateBlogPostCommandHandler
          : IRequestHandler<CreateBlogPostCommand, ApiResponse<BlogPostDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public CreateBlogPostCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<BlogPostDto>> Handle(
            CreateBlogPostCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                string imagePath = request.ImageUrl ?? string.Empty;
                if (request.ImageFile != null && request.ImageFile.Length > 0)
                {
                    imagePath = await _fileStorage.SaveFileAsync(request.ImageFile, "", cancellationToken);
                }

                var entity = new BlogPost
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = new LocalizedText { En = request.Title.En, Ar = request.Title.Ar },
                    Content = new LocalizedText { En = request.Content.En, Ar = request.Content.Ar },
                    Excerpt = new LocalizedText { En = request.Excerpt.En, Ar = request.Excerpt.Ar },
                    ImageUrl = imagePath,
                    Author = new LocalizedText { En = request.Author.En, Ar = request.Author.Ar },
                    PublishDate = request.PublishDate == default ? DateTime.UtcNow : request.PublishDate,
                    Category = new LocalizedText { En = request.Category.En, Ar = request.Category.Ar },
                    Tags = request.Tags ?? new List<List<object>>(),
                    ReadTime = request.ReadTime,
                    Featured = request.Featured
                };

                await _unitOfWork.BlogPosts.AddAsync(entity, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var dto = new BlogPostDto
                {
                    Id = entity.Id,
                    Title = request.Title,
                    Content = request.Content,
                    Excerpt = request.Excerpt,
                    ImageUrl = entity.ImageUrl,
                    Author = request.Author,
                    PublishDate = entity.PublishDate,
                    Category = request.Category,
                    Tags = entity.Tags,
                    ReadTime = entity.ReadTime,
                    Featured = entity.Featured
                };

                return new ApiResponse<BlogPostDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم إضافة المقال بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<BlogPostDto>
                {
                    Success = false,
                    Data = null,
                    Message = $"حدث خطأ أثناء إضافة المقال: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}