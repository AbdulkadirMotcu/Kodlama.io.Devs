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

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology
{
    public class DeleteLanguageTechnologyCommand:IRequest<DeletedLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public class DeleteLanguageTechnologyCommandHandler : IRequestHandler<DeleteLanguageTechnologyCommand, DeletedLanguageTechnologyDto>
        {
            private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
            private readonly IMapper _mapper;

            public DeleteLanguageTechnologyCommandHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper)
            {
                _languageTechnologyRepository = languageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<DeletedLanguageTechnologyDto> Handle(DeleteLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                LanguageTechnology mappedLanguageTechnology = _mapper.Map<LanguageTechnology>(request);
                LanguageTechnology createLanguageTechnology = await _languageTechnologyRepository.DeleteAsync(mappedLanguageTechnology);
                DeletedLanguageTechnologyDto deletedLanguageTechnologyDto = _mapper.Map<DeletedLanguageTechnologyDto>(createLanguageTechnology);

                return deletedLanguageTechnologyDto;
            }
        }
    }
}
