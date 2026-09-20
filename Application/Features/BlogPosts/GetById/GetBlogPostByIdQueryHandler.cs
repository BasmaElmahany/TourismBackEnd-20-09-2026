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

namespace Tourism.Application.Features.BlogPosts.GetById
{
    public class GetBlogPostByIdQueryHandler
        : IRequestHandler<GetBlogPostByIdQuery, ApiResponse<BlogPostDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBlogPostByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<BlogPostDto>> Handle(
            GetBlogPostByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var x = await _unitOfWork.BlogPosts.GetByIdAsync(request.Id, cancellationToken);

                if (x is null)
                {
                    return new ApiResponse<BlogPostDto>
                    {
                        Success = false,
                        Data = null,
                        Message = "المقال غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                var dto = new BlogPostDto
                {
                    Id = x.Id,
                    Title = new LocalizedTextDto { En = x.Title.En, Ar = x.Title.Ar },
                    Content = new LocalizedTextDto { En = x.Content.En, Ar = x.Content.Ar },
                    Excerpt = new LocalizedTextDto { En = x.Excerpt.En, Ar = x.Excerpt.Ar },
                    ImageUrl = x.ImageUrl,
                    Author = new LocalizedTextDto { En = x.Author.En, Ar = x.Author.Ar },
                    PublishDate = x.PublishDate,
                    Category = new LocalizedTextDto { En = x.Category.En, Ar = x.Category.Ar },
                    Tags = x.Tags ?? new List<List<object>>(),
                    ReadTime = x.ReadTime,
                    Featured = x.Featured
                };

                return new ApiResponse<BlogPostDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم جلب بيانات المقال بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<BlogPostDto>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ غير متوقع",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
