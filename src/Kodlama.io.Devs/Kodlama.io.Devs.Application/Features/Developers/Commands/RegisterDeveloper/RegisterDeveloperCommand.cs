using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Developers.Dtos;
using Kodlama.io.Devs.Application.Features.Developers.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Developers.Commands.RegisterDeveloper
{
    public class RegisterDeveloperCommand : UserForRegisterDto, IRequest<AccessTokenDto>
    {
        public class RegisterDeveloperCommandHandler : IRequestHandler<RegisterDeveloperCommand, AccessTokenDto>
        {
            private readonly IDeveloperRepository _developerRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly DeveloperBusinessRules _developerBusinessRules;

            public RegisterDeveloperCommandHandler(IDeveloperRepository developerRepository, IMapper mapper, ITokenHelper tokenHelper, DeveloperBusinessRules developerBusinessRules)
            {
                _developerRepository = developerRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _developerBusinessRules = developerBusinessRules;
            }

            public async Task<AccessTokenDto> Handle(RegisterDeveloperCommand request, CancellationToken cancellationToken)
            {
                _developerBusinessRules.EmailCanNotBeDuplicatedWhenInserted(request.Email);

                byte[] PasswordHash, PasswordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out PasswordHash, out PasswordSalt);

                Developer developer = _mapper.Map<Developer>(request);
                developer.PasswordHash = PasswordHash;
                developer.PasswordSalt = PasswordSalt;

                Developer CreateDeveloper = await _developerRepository.AddAsync(developer);

                var token = _tokenHelper.CreateToken(developer, new List<OperationClaim>());
                var createToken = _mapper.Map<AccessTokenDto>(token);    
                
                return createToken;
            }
        }
    }
}
