using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Models;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Queries.GetByIdLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageTechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageTechnologyCommand createLanguageTechnologyCommand)
        {
            CreatedLanguageTechnologyDto result = await Mediator.Send(createLanguageTechnologyCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageTechnologyCommand updateLanguageTechnologyCommand)
        {
            UpdatedLanguageTechnologyDto result = await Mediator.Send(updateLanguageTechnologyCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteLanguageTechnologyCommand deleteLanguageTechnologyCommand)
        {
            DeletedLanguageTechnologyDto result = await Mediator.Send(deleteLanguageTechnologyCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageTechnologyQuery getListLanguageTechnologyQuery = new() { PageRequest = pageRequest };
            LanguageTechnologyListModel languageTechnologyListModel = await Mediator.Send(getListLanguageTechnologyQuery);

            return Ok(languageTechnologyListModel); 

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLanguageTechnologyQuery getByIdLanguageTechnologyQuery)
        {
            LanguageTechnologyGeByIdDto languageTechnologyGeByIdDto = await Mediator.Send(getByIdLanguageTechnologyQuery);
            return Ok(languageTechnologyGeByIdDto);
        }


    }
}
