using OnionAPI.Application.Bases;

namespace OnionAPI.Application.Features.Auth.Exceptions
{
    public class SessionTimeExpiredException : BaseExceptions
    {
        public SessionTimeExpiredException() : base("Oturum suresi sona ermistir, lutfen tekrardan giris yapiniz.")
        {
            
        }
    }
}
