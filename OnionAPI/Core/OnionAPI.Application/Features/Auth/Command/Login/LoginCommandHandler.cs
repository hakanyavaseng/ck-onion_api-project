using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using OnionAPI.Application.Features.Auth.Rules;
using OnionAPI.Application.Interfaces.AutoMapper;
using OnionAPI.Application.Interfaces.Tokens;
using OnionAPI.Application.Interfaces.UnitOfWorks;
using OnionAPI.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace OnionAPI.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly AuthRules authRules;
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public LoginCommandHandler(AuthRules authRules,IUnitOfWork unitOfWork ,UserManager<User> userManager,ITokenService tokenService, IMapper mapper, IConfiguration configuration)
        {
            this.authRules = authRules;
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.mapper = mapper;
            this.configuration = configuration;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User? user = await userManager.FindByEmailAsync(request.Email);
            bool checkPassword = await userManager.CheckPasswordAsync(user, request.Password);

            await authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

            IList<string> userRoles = await userManager.GetRolesAsync(user);
            JwtSecurityToken jwtSecurityToken = await tokenService.CreateToken(user, userRoles);
            string refreshToken =  tokenService.GenerateRefreshToken();

            _ = int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int refresTokenValidityInDays);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpireDateTime = DateTime.Now.AddDays(refresTokenValidityInDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            string _token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

            await unitOfWork.SaveAsync();

            return new LoginCommandResponse
            {
                Token = _token,
                Expiration = jwtSecurityToken.ValidTo,
                RefreshToken = refreshToken
            };
        }
    }
}
