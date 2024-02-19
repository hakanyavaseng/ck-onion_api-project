using Microsoft.AspNetCore.Identity;

namespace OnionAPI.Domain.Entities.Identity
{
    public class User : IdentityUser<Guid>
    {
        public  string FullName { get; set; }
        public  string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDateTime { get; set; }
    }
}
