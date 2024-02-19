using OnionAPI.Application.Bases;
using OnionAPI.Application.Features.Auth.Command;
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
    }
}
