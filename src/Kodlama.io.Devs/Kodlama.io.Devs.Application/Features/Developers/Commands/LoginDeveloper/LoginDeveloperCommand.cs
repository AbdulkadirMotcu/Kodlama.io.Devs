using AutoMapper;
using Core.Security.Dtos;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Developers.Dtos;
using Kodlama.io.Devs.Application.Features.Developers.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Developers.Commands.LoginDeveloper
{
    public class LoginDeveloperCommand : UserForLoginDto, IRequest<AccessTokenDto>
    {
        public class LoginDeveloperCommandHandler : IRequestHandler<LoginDeveloperCommand, AccessTokenDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly DeveloperBusinessRules _developerBusinessRules;

            public LoginDeveloperCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, DeveloperBusinessRules developerBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _developerBusinessRules = developerBusinessRules;
            }

            public async Task<AccessTokenDto> Handle(LoginDeveloperCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(u => u.Email.ToLower() == request.Email.ToLower(),
                    include: m => m.Include(c => c.UserOperationClaims).ThenInclude(x => x.OperationClaim));

                var operationClaims = user.UserOperationClaims.Select(x => x.OperationClaim).ToList();

                _developerBusinessRules.UserExists(user);
                _developerBusinessRules.UserPasswordIsIncorrect(request.Password, user.PasswordHash, user.PasswordSalt);
                

                AccessToken token = _tokenHelper.CreateToken(user, operationClaims);

                AccessTokenDto accessTokenDto = _mapper.Map<AccessTokenDto>(token);
                return accessTokenDto;

            }
        }
    }
}
