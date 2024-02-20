using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionAPI.Application.Features.Auth.Command.Login;
using OnionAPI.Application.Features.Auth.Command.RefreshToken;
using OnionAPI.Application.Features.Auth.Command.Register;
using OnionAPI.Application.Features.Auth.Command.Revoke;
using OnionAPI.Application.Features.Auth.Command.RevokeAll;

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
            LoginCommandResponse loginCommandResponse = await mediator.Send(loginCommandRequest);
            return StatusCode(StatusCodes.Status202Accepted, loginCommandResponse);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest refreshTokenCommandRequest)
        {
            RefreshTokenCommandResponse refreshTokenCommandResponse = await mediator.Send(refreshTokenCommandRequest);
            return StatusCode(StatusCodes.Status202Accepted, refreshTokenCommandResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Revoke(RevokeCommandRequest revokeCommandRequest)
        {
            await mediator.Send(revokeCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeAll()
        {
            await mediator.Send(new RevokeAllCommandRequest());
            return StatusCode(StatusCodes.Status200OK);
        }



    }
}
