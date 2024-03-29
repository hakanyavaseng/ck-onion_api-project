﻿using OnionAPI.Application.Bases;
using OnionAPI.Application.Features.Auth.Command;
using OnionAPI.Application.Features.Auth.Exceptions;
using OnionAPI.Domain.Entities.Identity;

namespace OnionAPI.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }

        public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool checkPassword)
        {
            if (user is null || !checkPassword) throw new EmailOrPasswordShouldNotBeInvalidException();
            return Task.CompletedTask;
        } 

        public Task SessionTimeExpired(DateTime? expiryTime)
        {
            if (expiryTime <= DateTime.Now)
               throw new SessionTimeExpiredException();
            return Task.CompletedTask;

        }

        public Task EmailAddressShouldBeValid(User? user) 
        {
            if (user is null)
                throw new EmailAddressShouldBeValidException();
            return Task.CompletedTask;
        }
    }
}
