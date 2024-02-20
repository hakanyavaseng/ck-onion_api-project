using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OnionAPI.Application.Features.Auth.Rules;
using OnionAPI.Application.Interfaces.AutoMapper;
using OnionAPI.Application.Interfaces.Tokens;
using OnionAPI.Application.Interfaces.UnitOfWorks;
using OnionAPI.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnionAPI.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        private readonly AuthRules authRules;

        public RefreshTokenCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ITokenService tokenService, AuthRules authRules)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.authRules = authRules;
        }
        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            var principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);

            string email = principal.FindFirstValue(ClaimTypes.Email);

            User? user = await userManager.FindByEmailAsync(email);
            IList<string> roles = await userManager.GetRolesAsync(user);

            await authRules.SessionTimeExpired(user.RefreshTokenExpireDateTime);

            JwtSecurityToken newAccessToken = await tokenService.CreateToken(user, roles);
            string newRefreshToken = tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await userManager.UpdateAsync(user);
            await unitOfWork.SaveAsync();

            return new RefreshTokenCommandResponse()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken,
            };

        }
    }
}
