using Kodlama.io.Devs.Application.Features.Developers.Commands.LoginDeveloper;
using Kodlama.io.Devs.Application.Features.Developers.Commands.RegisterDeveloper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDeveloperCommand registerDeveloperCommand)
        {
            var result = await Mediator.Send(registerDeveloperCommand);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDeveloperCommand loginDeveloperCommand)
        {
            var result = await Mediator.Send(loginDeveloperCommand);

            return Ok(result);
        }

    }
}
