using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.DTOs;
using Tourism.Application.Features.Events.Create;
using Tourism.Application.Features.Events.GetAll;

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

        //[HttpPost]
        //[Consumes("multipart/form-data")]
        //public async Task<ActionResult<ApiResponse<string>>> Create(
        //    [FromForm] string eventDataJson,
        //    [FromForm] IFormFile? image,
        //    CancellationToken cancellationToken)
        //{
        //    var eventDto = JsonSerializer.Deserialize<CreateTourismEventDto>(
        //        eventDataJson,
        //        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        //    );

        //    if (eventDto == null)
        //    {
        //        return BadRequest(new ApiResponse<string>
        //        {
        //            Success = false,
        //            Message = "بيانات الفعالية غير صالحة",
        //            Code = StatusCodes.Status400BadRequest
        //        });
        //    }

        //    var response = await _sender.Send(new CreateTourismEventCommand(eventDto, image), cancellationToken);
        //    return StatusCode(response.Code, response);
        //}
    }
}