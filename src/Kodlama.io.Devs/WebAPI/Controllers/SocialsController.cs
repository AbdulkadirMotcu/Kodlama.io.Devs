using Kodlama.io.Devs.Application.Features.Socials.Commands.CreateSocialCommands;
using Kodlama.io.Devs.Application.Features.Socials.Commands.DeleteSocial;
using Kodlama.io.Devs.Application.Features.Socials.Commands.UpdateSocial;
using Kodlama.io.Devs.Application.Features.Socials.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialCommand createSocialCommand)
        {
            CreatedSocialDto result = await Mediator.Send(createSocialCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSocialCommad updateSocialCommad)
        {
            UpdatedSocialDto result = await Mediator.Send(updateSocialCommad);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteSocialCommand deleteSocialCommand)
        {
            DeletedSocialDto result = await Mediator.Send(deleteSocialCommand);
            return Ok(result);
        }
    }
}
