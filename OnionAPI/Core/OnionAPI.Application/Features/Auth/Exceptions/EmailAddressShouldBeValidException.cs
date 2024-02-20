using OnionAPI.Application.Bases;

namespace OnionAPI.Application.Features.Auth.Exceptions
{
    public class EmailAddressShouldBeValidException : BaseExceptions
    {
        public EmailAddressShouldBeValidException() : base("Bu email adresi ile bir kullanici bulunamadi.")
        {
            
        }
    }
}
