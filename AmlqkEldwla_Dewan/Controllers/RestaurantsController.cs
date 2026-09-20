using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.Features.Restaurants.BulkCreate;
using Tourism.Application.Features.Restaurants.Create;
using Tourism.Application.Features.Restaurants.Delete;
using Tourism.Application.Features.Restaurants.GetAll;
using Tourism.Application.Features.Restaurants.GetById;
using Tourism.Application.Features.Restaurants.Update;

namespace Tourism.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly ISender _sender;

        public RestaurantsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<RestaurantDto>>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetAllRestaurantsQuery(), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<RestaurantDto>>> GetById(string id, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetRestaurantByIdQuery(id), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ApiResponse<RestaurantDto>>> Create(
            [FromForm] CreateRestaurantCommand command,
            CancellationToken cancellationToken)
        {
            var response = await _sender.Send(command, cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ApiResponse<bool>>> Update(
            string id,
            [FromForm] UpdateRestaurantCommand command,
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
            var response = await _sender.Send(new DeleteRestaurantCommand(id), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPost("bulk")]
        public async Task<ActionResult<ApiResponse<int>>> BulkCreate(
    [FromBody] List<RestaurantDto> restaurants,
    CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new BulkCreateRestaurantsCommand(restaurants), cancellationToken);
            return StatusCode(response.Code, response);
        }
    }
}