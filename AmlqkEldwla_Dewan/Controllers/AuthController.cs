using Tourism.Application.Features.Authentication.Commands.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tourism.API.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


      //  [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
