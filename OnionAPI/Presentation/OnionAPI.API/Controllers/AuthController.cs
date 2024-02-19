using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionAPI.Application.Features.Auth.Command.Login;
using OnionAPI.Application.Features.Auth.Command.Register;

namespace OnionAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest registerCommandRequest)
        {
            await mediator.Send(registerCommandRequest);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest loginCommandRequest)
        {
            LoginCommandResponse loginCommandResponse =  await mediator.Send(loginCommandRequest);
            return StatusCode(StatusCodes.Status202Accepted, loginCommandResponse);
        }


    }
}
