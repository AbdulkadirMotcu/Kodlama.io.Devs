using AutoMapper;
using FluentValidation.Resources;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology
{
    public class UpdateLanguageTechnologyCommand:IRequest<UpdatedLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public class UpdateLanguageTechnologyCommandHandler : IRequestHandler<UpdateLanguageTechnologyCommand, UpdatedLanguageTechnologyDto>
        {
            private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
            private readonly IMapper _mapper;

            public UpdateLanguageTechnologyCommandHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper)
            {
                _languageTechnologyRepository = languageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedLanguageTechnologyDto> Handle(UpdateLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                LanguageTechnology mappedLanguageManager = _mapper.Map<LanguageTechnology>(request);
                LanguageTechnology createLanguageManager = await _languageTechnologyRepository.UpdateAsync(mappedLanguageManager);
                UpdatedLanguageTechnologyDto updatedLanguageTechnologyDto = _mapper.Map<UpdatedLanguageTechnologyDto>(createLanguageManager);

                return updatedLanguageTechnologyDto;

            }
        }
    }
}
