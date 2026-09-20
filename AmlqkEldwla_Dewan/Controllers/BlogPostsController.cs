using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.Features.BlogPosts.BulkCreate;
using Tourism.Application.Features.BlogPosts.Create;
using Tourism.Application.Features.BlogPosts.Delete;
using Tourism.Application.Features.BlogPosts.GetAll;
using Tourism.Application.Features.BlogPosts.GetById;
using Tourism.Application.Features.BlogPosts.Update;

namespace Tourism.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostsController : ControllerBase
    {
        private readonly ISender _sender;

        public BlogPostsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<BlogPostDto>>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetAllBlogPostsQuery(), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<BlogPostDto>>> GetById(string id, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetBlogPostByIdQuery(id), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ApiResponse<BlogPostDto>>> Create(
            [FromForm] CreateBlogPostCommand command,
            CancellationToken cancellationToken)
        {
            var response = await _sender.Send(command, cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPost("bulk")]
        public async Task<ActionResult<ApiResponse<int>>> BulkCreate(
            [FromBody] List<BlogPostDto> blogPosts,
            CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new BulkCreateBlogPostsCommand(blogPosts), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ApiResponse<bool>>> Update(
            string id,
            [FromForm] UpdateBlogPostCommand command,
            CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return BadRequest(new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "معرف المسار لا يطابق معرف الطلب",
                    Code = StatusCodes.Status400BadRequest
                });
            }

            var response = await _sender.Send(command, cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(string id, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new DeleteBlogPostCommand(id), cancellationToken);
            return StatusCode(response.Code, response);
        }
    }
}