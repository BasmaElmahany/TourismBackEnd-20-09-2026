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

namespace Tourism.Application.Features.BlogPosts.GetAll
{
    public class GetAllBlogPostsQueryHandler
        : IRequestHandler<GetAllBlogPostsQuery, ApiResponse<List<BlogPostDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBlogPostsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<BlogPostDto>>> Handle(
            GetAllBlogPostsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var posts = await _unitOfWork.BlogPosts.GetAllAsync(cancellationToken);

                var dtos = posts.Select(x => new BlogPostDto
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
                }).ToList();

                return new ApiResponse<List<BlogPostDto>>
                {
                    Success = true,
                    Data = dtos,
                    Message = "تم جلب المقالات بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<List<BlogPostDto>>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ أثناء جلب المقالات",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}