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

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Queries.GetByIdLanguageTechnology
{
    public class GetByIdLanguageTechnologyQuery:IRequest<LanguageTechnologyGeByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdLanguageTechnologyQueryHandler : IRequestHandler<GetByIdLanguageTechnologyQuery, LanguageTechnologyGeByIdDto>
        {
            private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
            private readonly IMapper _mapper;

            public GetByIdLanguageTechnologyQueryHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper)
            {
                _languageTechnologyRepository = languageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<LanguageTechnologyGeByIdDto> Handle(GetByIdLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                LanguageTechnology languageTechnology = await _languageTechnologyRepository.GetAsync(l => l.Id == request.Id);

                LanguageTechnologyGeByIdDto languageTechnologyGeByIdDto = _mapper.Map<LanguageTechnologyGeByIdDto>(languageTechnology);

                return languageTechnologyGeByIdDto;
            }
        }
    }
}
