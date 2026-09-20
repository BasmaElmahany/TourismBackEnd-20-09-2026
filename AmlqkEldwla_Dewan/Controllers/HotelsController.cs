using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.Features.Hotels.BulkCreate;
using Tourism.Application.Features.Hotels.Create;
using Tourism.Application.Features.Hotels.Delete;
using Tourism.Application.Features.Hotels.GetAll;
using Tourism.Application.Features.Hotels.GetById;
using Tourism.Application.Features.Hotels.Update;

namespace Tourism.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly ISender _sender;

        public HotelsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<HotelDto>>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetAllHotelsQuery(), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<HotelDto>>> GetById(string id, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetHotelByIdQuery(id), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ApiResponse<HotelDto>>> Create(
            [FromForm] CreateHotelCommand command,
            CancellationToken cancellationToken)
        {
            var response = await _sender.Send(command, cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ApiResponse<bool>>> Update(
            string id,
            [FromForm] UpdateHotelCommand command,
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
            var response = await _sender.Send(new DeleteHotelCommand(id), cancellationToken);
            return StatusCode(response.Code, response);
        }



        [HttpPost("bulk")]
        public async Task<ActionResult<ApiResponse<int>>> BulkCreate( [FromBody] List<HotelDto> hotels,CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new BulkCreateHotelsCommand(hotels), cancellationToken);
            return StatusCode(response.Code, response);
        }
    }
}