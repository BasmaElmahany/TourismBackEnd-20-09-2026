using MediatR;
using Microsoft.AspNetCore.Mvc;

using System.Text.Json;

using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.DTOs;
using Tourism.Application.Features.Events.Create;
using Tourism.Application.Features.Events.Delete;
using Tourism.Application.Features.Events.GetAll;
using Tourism.Application.Features.Events.GetById;
using Tourism.Application.Features.Events.Update;

namespace Tourism.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourismEventsController : ControllerBase
    {
        private readonly ISender _sender;

        public TourismEventsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<TourismEventDto>>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetAllTourismEventsQuery(), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<TourismEventDto>>> Create(
     [FromForm] TourismEventFormRequest request,
     CancellationToken cancellationToken)
        {
            var eventDto = JsonSerializer.Deserialize<CreateTourismEventDto>(
                request.EventDataJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (eventDto == null)
            {
                return BadRequest(new ApiResponse<TourismEventDto>
                {
                    Success = false,
                    Message = "بيانات الفعالية غير صالحة",
                    Code = StatusCodes.Status400BadRequest
                });
            }

            var command = new CreateTourismEventCommand(
                eventDto.Name,
                eventDto.Description,
                request.Image,
                eventDto.ImageUrl,
                eventDto.StartDate,
                eventDto.EndDate,
                eventDto.Location,
                eventDto.Latitude,
                eventDto.Longitude,
                eventDto.TicketPrice,
                eventDto.IsFree,
                eventDto.Category,
                eventDto.Organizer,
                eventDto.ContactInfo
            );

            var response = await _sender.Send(command, cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<TourismEventDto>>> Update(
            [FromRoute] string id,
            [FromForm] TourismEventFormRequest request,
            CancellationToken cancellationToken)
        {
            var eventDto = JsonSerializer.Deserialize<CreateTourismEventDto>(
                request.EventDataJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (eventDto == null)
            {
                return BadRequest(new ApiResponse<TourismEventDto>
                {
                    Success = false,
                    Message = "البيانات المدخلة غير صحيحة",
                    Code = StatusCodes.Status400BadRequest
                });
            }

            var command = new UpdateTourismEventCommand(
                id,
                eventDto.Name,
                eventDto.Description,
                request.Image,
                eventDto.ImageUrl,
                eventDto.StartDate,
                eventDto.EndDate,
                eventDto.Location,
                eventDto.Latitude,
                eventDto.Longitude,
                eventDto.TicketPrice,
                eventDto.IsFree,
                eventDto.Category,
                eventDto.Organizer,
                eventDto.ContactInfo
            );

            var response = await _sender.Send(command, cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(
       [FromRoute] string id,
       CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new DeleteTourismEventCommand(id), cancellationToken);
            return StatusCode(response.Code, response);
        }

    }
}