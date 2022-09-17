using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Socials.Commands.DeleteSocial
{
    public class DeleteSocialValidator:AbstractValidator<DeleteSocialCommand>
    {
        public DeleteSocialValidator()
        {
            //RuleFor(s=>s.DeveloperId).NotEmpty();
            //RuleFor(s => s.GitHubProfile).NotEmpty();
        }
    }
}
