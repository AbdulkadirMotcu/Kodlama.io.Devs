using AutoMapper;
using Kodlama.io.Devs.Application.Features.Socials.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Socials.Commands.CreateSocialCommands
{
    public class CreateSocialCommand:IRequest<CreatedSocialDto>
    {
        public int DeveloperId { get; set; }
        public string GitHubProfile { get; set; }


        public class CreateSocialCommandHandler : IRequestHandler<CreateSocialCommand, CreatedSocialDto>
        {
            private readonly ISocialRepository _socialRepository;
            private readonly IMapper _mapper;

            public CreateSocialCommandHandler(ISocialRepository repository, IMapper mapper)
            {
                _socialRepository = repository;
                _mapper = mapper;
            }

            public async Task<CreatedSocialDto> Handle(CreateSocialCommand request, CancellationToken cancellationToken)
            {
                Social mappedSocial= _mapper.Map<Social>(request);
                Social createSocial = await _socialRepository.AddAsync(mappedSocial);
                CreatedSocialDto createSocialDto = _mapper.Map<CreatedSocialDto>(createSocial);

                return createSocialDto;

            }
        }
    }
}
