using MediatR;

namespace OnionAPI.Application.Features.Auth.Command.Register
{
    public class RegisterCommandRequest : IRequest<Unit> //Unit is added for pipeline behaviour problem
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
