using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.Features.Photographers.Create;
using Tourism.Application.Features.Photographers.Delete;
using Tourism.Application.Features.Photographers.GetAll;
using Tourism.Application.Features.Photographers.GetById;
using Tourism.Application.Features.Photographers.Update;

namespace Tourism.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotographersController : ControllerBase
    {
        private readonly ISender _sender;

        public PhotographersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<PhotographerDto>>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetAllPhotographersQuery(), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<PhotographerDto>>> GetById(string id, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetPhotographerByIdQuery(id), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<PhotographerDto>>> Create([FromForm] CreatePhotographerCommand command, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(command, cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> Update(string id, [FromForm] UpdatePhotographerCommand command, CancellationToken cancellationToken)
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
            var response = await _sender.Send(new DeletePhotographerCommand(id), cancellationToken);
            return StatusCode(response.Code, response);
        }
    }
}