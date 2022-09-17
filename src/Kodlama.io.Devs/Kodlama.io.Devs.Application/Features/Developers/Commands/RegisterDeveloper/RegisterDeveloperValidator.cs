using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Developers.Commands.RegisterDeveloper
{
    public class RegisterDeveloperValidator:AbstractValidator<RegisterDeveloperCommand>
    {
        public RegisterDeveloperValidator()
        {
            RuleFor(d=>d.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(d=>d.Password).NotEmpty().NotNull().Length(8,25).WithMessage("Password alanı 8 ile 25 karakter arasında olmalıdır!");
            RuleFor(d=>d.FirstName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(d=>d.LastName).NotNull().NotEmpty().MinimumLength(2);
        }
    }
}
