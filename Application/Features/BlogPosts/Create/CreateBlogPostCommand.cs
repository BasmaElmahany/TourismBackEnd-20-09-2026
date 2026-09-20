using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.BlogPosts.Create
{
    public record CreateBlogPostCommand(
          LocalizedTextDto Title,
          LocalizedTextDto Content,
          LocalizedTextDto Excerpt,
          IFormFile? ImageFile,         
          string? ImageUrl,                
          LocalizedTextDto Author,
          DateTime PublishDate,
          LocalizedTextDto Category,
          List<List<object>>? Tags,
          int ReadTime,
          bool Featured
      ) : IRequest<ApiResponse<BlogPostDto>>;
}
