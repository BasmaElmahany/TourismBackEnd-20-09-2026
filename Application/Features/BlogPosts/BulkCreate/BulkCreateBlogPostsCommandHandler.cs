using MediatR;
using Microsoft.AspNetCore.Http;
using Tourism.Application.Common.DTOs;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities.Common;
using Tourism.Domain.Entities;

namespace Tourism.Application.Features.BlogPosts.BulkCreate
{
    public class BulkCreateBlogPostsCommandHandler
         : IRequestHandler<BulkCreateBlogPostsCommand, ApiResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BulkCreateBlogPostsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<int>> Handle(
            BulkCreateBlogPostsCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (request.BlogPosts == null || !request.BlogPosts.Any())
                {
                    return new ApiResponse<int>
                    {
                        Success = false,
                        Data = 0,
                        Message = "قائمة المقالات فارغة",
                        Code = StatusCodes.Status400BadRequest
                    };
                }

                var entities = request.BlogPosts.Select(item => new BlogPost
                {
                    Id = string.IsNullOrWhiteSpace(item.Id) ? Guid.NewGuid().ToString() : item.Id,
                    Title = new LocalizedText
                    {
                        En = item.Title?.En ?? string.Empty,
                        Ar = item.Title?.Ar ?? string.Empty
                    },
                    Content = new LocalizedText
                    {
                        En = item.Content?.En ?? string.Empty,
                        Ar = item.Content?.Ar ?? string.Empty
                    },
                    Excerpt = new LocalizedText
                    {
                        En = item.Excerpt?.En ?? string.Empty,
                        Ar = item.Excerpt?.Ar ?? string.Empty
                    },
                    ImageUrl = item.ImageUrl?.ToString() ?? string.Empty,
                    Author = new LocalizedText
                    {
                        En = item.Author?.En ?? string.Empty,
                        Ar = item.Author?.Ar ?? string.Empty
                    },
                    PublishDate = item.PublishDate == default ? DateTime.UtcNow : item.PublishDate,
                    Category = new LocalizedText
                    {
                        En = item.Category?.En ?? string.Empty,
                        Ar = item.Category?.Ar ?? string.Empty
                    },
                    Tags = item.Tags ?? new List<List<object>>(),
                    ReadTime = item.ReadTime,
                    Featured = item.Featured
                }).ToList();

                foreach (var entity in entities)
                {
                    await _unitOfWork.BlogPosts.AddAsync(entity, cancellationToken);
                }

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<int>
                {
                    Success = true,
                    Data = entities.Count,
                    Message = $"تم إضافة {entities.Count} مقالاً بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Data = 0,
                    Message = $"حدث خطأ أثناء الإدخال الجماعي للمقالات: {ex.InnerException?.Message ?? ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}

