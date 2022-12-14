using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Developers.Commands.LoginDeveloper
{
    public class LoginDeveloperValidator : AbstractValidator<LoginDeveloperCommand>
    {
        public LoginDeveloperValidator()
        {
            RuleFor(d=>d.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(d=>d.Password).NotEmpty().NotNull().MinimumLength(8);   
        }
    }
}
