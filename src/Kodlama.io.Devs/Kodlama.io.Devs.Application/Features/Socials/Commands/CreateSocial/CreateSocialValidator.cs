using FluentValidation;
using Kodlama.io.Devs.Application.Features.Socials.Commands.CreateSocialCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Socials.Commands.CreateSocial
{
    public class CreateSocialValidator:AbstractValidator<CreateSocialCommand>
    {
        public CreateSocialValidator()
        {
            RuleFor(s => s.DeveloperId).NotNull().NotEmpty();
            RuleFor(s => s.GitHubProfile).NotEmpty().NotNull();
        }
    }
}
