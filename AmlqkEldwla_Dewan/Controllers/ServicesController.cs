using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.Features.Services.BulkCreate;
using Tourism.Application.Features.Services.Create;
using Tourism.Application.Features.Services.Delete;
using Tourism.Application.Features.Services.GetAll;
using Tourism.Application.Features.Services.GetById;
using Tourism.Application.Features.Services.Updatee;

namespace Tourism.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ISender _sender;

        public ServicesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ServiceItemDto>>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetAllServicesQuery(), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ServiceItemDto>>> GetById(string id, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetServiceByIdQuery(id), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ApiResponse<ServiceItemDto>>> Create(
            [FromForm] CreateServiceCommand command,
            CancellationToken cancellationToken)
        {
            var response = await _sender.Send(command, cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ApiResponse<bool>>> Update(
            string id,
            [FromForm] UpdateServiceCommand command,
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
            var response = await _sender.Send(new DeleteServiceCommand(id), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPost("bulk")]
        public async Task<ActionResult<ApiResponse<int>>> BulkCreate([FromBody] List<ServiceItemDto> services,CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new BulkCreateServicesCommand(services), cancellationToken);
            return StatusCode(response.Code, response);
        }
    }
}