using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommandValidator:AbstractValidator<CreateProgrammingLanguageCommand>
    {
        public CreateProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);  
        }
    }
}
