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

namespace Kodlama.io.Devs.Application.Features.Socials.Commands.UpdateSocial
{
    public class UpdateSocialCommad : IRequest<UpdatedSocialDto>
    {
        public int Id { get; set; }
        public int DeveloperId { get; set; }
        public string GitHubProfile { get; set; }

        public class UpdateSocialCommadHandler : IRequestHandler<UpdateSocialCommad, UpdatedSocialDto>
        {
            private readonly ISocialRepository _socialRepository;
            private readonly IMapper _mapper;

            public UpdateSocialCommadHandler(ISocialRepository socialRepository, IMapper mapper)
            {
                _socialRepository = socialRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedSocialDto> Handle(UpdateSocialCommad request, CancellationToken cancellationToken)
            {
                Social mappedSocial = _mapper.Map<Social>(request);
                Social updateSocial = await _socialRepository.UpdateAsync(mappedSocial);
                UpdatedSocialDto updatedSocialDto = _mapper.Map<UpdatedSocialDto>(updateSocial);

                return updatedSocialDto;

            }
        }
    }
}
