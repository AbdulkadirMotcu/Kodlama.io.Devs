using AutoMapper;
using Kodlama.io.Devs.Application.Features.Socials.Commands.CreateSocialCommands;
using Kodlama.io.Devs.Application.Features.Socials.Commands.DeleteSocial;
using Kodlama.io.Devs.Application.Features.Socials.Commands.UpdateSocial;
using Kodlama.io.Devs.Application.Features.Socials.Dtos;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Socials.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Social, CreateSocialCommand>().ReverseMap();
            CreateMap<Social, CreatedSocialDto>().ReverseMap();

            CreateMap<Social, DeleteSocialCommand>().ReverseMap();
            CreateMap<Social, DeletedSocialDto>().ReverseMap();

            CreateMap<Social, UpdateSocialCommad>().ReverseMap();
            CreateMap<Social, UpdatedSocialDto>().ReverseMap();

        }
    }
}
