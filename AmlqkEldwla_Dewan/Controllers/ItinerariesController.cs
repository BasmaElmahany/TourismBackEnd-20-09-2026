using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.DTOs;
using Tourism.Application.Features.Itinerary.BulkCreate;
using Tourism.Application.Features.Itinerary.GetAll;

namespace Tourism.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItinerariesController : ControllerBase
    {
        private readonly ISender _sender;

        public ItinerariesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ItineraryDto>>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetAllItinerariesQuery(), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPost("bulk")]
        public async Task<ActionResult<ApiResponse<int>>> BulkCreate(
            [FromBody] List<ItineraryDto> itineraries,
            CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new BulkCreateItinerariesCommand(itineraries), cancellationToken);
            return StatusCode(response.Code, response);
        }
    }
}
