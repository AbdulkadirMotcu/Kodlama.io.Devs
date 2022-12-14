using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Socials.Dtos
{
    public class UpdatedSocialDto
    {
        public int Id { get; set; }
        public int DeveloperId { get; set; }
        public string GitHubProfile { get; set; }
    }
}
