using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.Features.Souvenir.BulkCreate;
using Tourism.Application.Features.Souvenir.Create;
using Tourism.Application.Features.Souvenir.CreateSouvenirProduct;
using Tourism.Application.Features.Souvenir.Delete;
using Tourism.Application.Features.Souvenir.DeleteSouvenirProduct;
using Tourism.Application.Features.Souvenir.GetAll;
using Tourism.Application.Features.Souvenir.GetAllSouvenirCategories;
using Tourism.Application.Features.Souvenir.GetById;
using Tourism.Application.Features.Souvenir.GetProductsByShopId;
using Tourism.Application.Features.Souvenir.Update;

namespace Tourism.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SouvenirsController : ControllerBase
    {
        private readonly ISender _sender;

        public SouvenirsController(ISender sender)
        {
            _sender = sender;
        }

        // --- Categories ---
        [HttpGet("categories")]
        public async Task<ActionResult<ApiResponse<List<SouvenirCategoryDto>>>> GetCategories(CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetAllSouvenirCategoriesQuery(), cancellationToken);
            return StatusCode(response.Code, response);
        }

        // --- Shops ---
        [HttpGet("shops")]
        public async Task<ActionResult<ApiResponse<List<SouvenirShopDto>>>> GetAllShops(CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetAllSouvenirShopsQuery(), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpGet("shops/{id}")]
        public async Task<ActionResult<ApiResponse<SouvenirShopDto>>> GetShopById(string id, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetSouvenirShopByIdQuery(id), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPost("shops")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ApiResponse<SouvenirShopDto>>> CreateShop(
            [FromForm] CreateSouvenirShopCommand command,
            CancellationToken cancellationToken)
        {
            var response = await _sender.Send(command, cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPost("shops/bulk")]
        public async Task<ActionResult<ApiResponse<int>>> BulkCreateShops(
            [FromBody] List<SouvenirShopDto> shops,
            CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new BulkCreateSouvenirShopsCommand(shops), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPut("shops/{id}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateShop(
            string id,
            [FromForm] UpdateSouvenirShopCommand command,
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

        [HttpDelete("shops/{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteShop(string id, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new DeleteSouvenirShopCommand(id), cancellationToken);
            return StatusCode(response.Code, response);
        }

        // --- Products ---
        [HttpGet("shops/{shopId}/products")]
        public async Task<ActionResult<ApiResponse<List<SouvenirProductDto>>>> GetProductsByShop(string shopId, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new GetProductsByShopIdQuery(shopId), cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpPost("products")]
        public async Task<ActionResult<ApiResponse<SouvenirProductDto>>> CreateProduct(
            [FromBody] CreateSouvenirProductCommand command,
            CancellationToken cancellationToken)
        {
            var response = await _sender.Send(command, cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpDelete("products/{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteProduct(string id, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new DeleteSouvenirProductCommand(id), cancellationToken);
            return StatusCode(response.Code, response);
        }
    }
}