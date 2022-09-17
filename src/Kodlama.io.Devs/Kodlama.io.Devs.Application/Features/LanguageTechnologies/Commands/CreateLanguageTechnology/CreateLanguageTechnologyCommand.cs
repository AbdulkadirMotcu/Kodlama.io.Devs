using AutoMapper;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology
{
    public class CreateLanguageTechnologyCommand:IRequest<CreatedLanguageTechnologyDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public class CreateLanguageTechnologyCommandHandler : IRequestHandler<CreateLanguageTechnologyCommand, CreatedLanguageTechnologyDto>
        {
            private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
            private readonly IMapper _mapper;

            public CreateLanguageTechnologyCommandHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper)
            {
                _languageTechnologyRepository = languageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<CreatedLanguageTechnologyDto> Handle(CreateLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                LanguageTechnology mappedLanguageTechnology = _mapper.Map<LanguageTechnology>(request);
                LanguageTechnology createLanguageTechnology = await _languageTechnologyRepository.AddAsync(mappedLanguageTechnology);
                CreatedLanguageTechnologyDto createdLanguageTechnologyDto = _mapper.Map<CreatedLanguageTechnologyDto>(createLanguageTechnology);

                return createdLanguageTechnologyDto;


                 
            }
        }
    }
}
