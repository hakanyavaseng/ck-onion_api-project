using MediatR;
using Microsoft.AspNetCore.Identity;
using OnionAPI.Application.Features.Auth.Rules;
using OnionAPI.Application.Interfaces.UnitOfWorks;
using OnionAPI.Domain.Entities.Identity;

namespace OnionAPI.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommandHandler : IRequestHandler<RevokeCommandRequest, Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly AuthRules authRules;
        private readonly IUnitOfWork unitOfWork;

        public RevokeCommandHandler(UserManager<User> userManager, AuthRules authRules, IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.authRules = authRules;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
        {
            User? user = await userManager.FindByEmailAsync(request.Email);
            await authRules.EmailAddressShouldBeValid(user);

            user.RefreshToken = null;
            await userManager.UpdateAsync(user);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
