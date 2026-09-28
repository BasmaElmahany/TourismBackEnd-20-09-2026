using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Attractions.BulkCreate;
using Tourism.Application.Features.Attractions.Create;
using Tourism.Application.Features.Attractions.Delete;
using Tourism.Application.Features.Attractions.getById;
using Tourism.Application.Features.Attractions.List;
using Tourism.Application.Features.Attractions.Update;

using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttractionsController : ControllerBase
    {
        private readonly ISender _sender;

        public AttractionsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<AttractionDto>>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetAllAttractionsQuery(), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<AttractionDto>>> GetById(string id, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetAttractionByIdQuery(id), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ApiResponse<AttractionDto>>> Create(
     [FromForm] CreateAttractionCommand command,
     CancellationToken cancellationToken)
        {
            var response = await _sender.Send(command, cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ApiResponse<bool>>> Update(
        string id,
        [FromForm] UpdateAttractionCommand command,
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
            var response = await _sender.Send(new DeleteAttractionCommand(id), cancellationToken);
            return StatusCode(response.Code, response);
        }


        [HttpPost("bulk")]
        public async Task<ActionResult<ApiResponse<int>>> BulkCreate(
    [FromBody] List<AttractionDto> attractions,
    CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new BulkCreateAttractionsCommand(attractions), cancellationToken);
            return StatusCode(response.Code, response);
        }
    }
}