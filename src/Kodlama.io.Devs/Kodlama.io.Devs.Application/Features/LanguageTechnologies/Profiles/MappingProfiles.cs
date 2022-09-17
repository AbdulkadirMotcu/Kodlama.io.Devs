using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Models;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<LanguageTechnology, CreateLanguageTechnologyCommand>().ReverseMap();
            CreateMap<LanguageTechnology, CreatedLanguageTechnologyDto>().ReverseMap();

            CreateMap<LanguageTechnology, DeleteLanguageTechnologyCommand>().ReverseMap();
            CreateMap<LanguageTechnology, DeletedLanguageTechnologyDto>().ReverseMap();

            CreateMap<LanguageTechnology, UpdateLanguageTechnologyCommand>().ReverseMap();
            CreateMap<LanguageTechnology, UpdatedLanguageTechnologyDto>().ReverseMap();

            CreateMap<IPaginate<LanguageTechnology>, LanguageTechnologyListModel>().ReverseMap();
            CreateMap<LanguageTechnology, LanguageTechnologyListDto>();

            CreateMap<LanguageTechnology, LanguageTechnologyGeByIdDto>().ReverseMap();


        }
    }
}
