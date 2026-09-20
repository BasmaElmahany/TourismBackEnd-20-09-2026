using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.Features.TourismInfos.Create;
using Tourism.Application.Features.TourismInfos.Delete;
using Tourism.Application.Features.TourismInfos.GetAll;
using Tourism.Application.Features.TourismInfos.GetById;
using Tourism.Application.Features.TourismInfos.Update;

namespace Tourism.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourismInfoController : ControllerBase
    {
        private readonly ISender _sender;

        public TourismInfoController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<TourismInfoDto>>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetAllTourismInfosQuery(), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<TourismInfoDto>>> GetById(string id, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetTourismInfoByIdQuery(id), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<TourismInfoDto>>> Create([FromBody] CreateTourismInfoCommand command, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(command, cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> Update(string id, [FromBody] UpdateTourismInfoCommand command, CancellationToken cancellationToken)
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
            var response = await _sender.Send(new DeleteTourismInfoCommand(id), cancellationToken);
            return StatusCode(response.Code, response);
        }
    }
}