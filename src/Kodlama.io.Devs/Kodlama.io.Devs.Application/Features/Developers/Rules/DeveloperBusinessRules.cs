using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Developers.Rules
{
    public class DeveloperBusinessRules
    {
        private readonly IUserRepository _userRepository;
        //login
        public void UserExists(User user)
        {
            if (user == null) throw new BusinessException("Kullanıcı yok");
        }
        public void UserPasswordIsIncorrect(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!result) throw new BusinessException("Kullanıcı şifresi yanlış");
        }




        //register
        public void EmailCanNotBeDuplicatedWhenInserted(string email)
        {
            var result = _userRepository.GetAsync(u => u.Email.ToLower() == email.ToLower());
            if (result != null) throw new BusinessException("E-posta adresi zaten var");
        }


    }
}
