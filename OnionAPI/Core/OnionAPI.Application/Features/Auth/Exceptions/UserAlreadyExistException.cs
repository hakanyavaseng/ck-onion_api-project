using OnionAPI.Application.Bases;

namespace OnionAPI.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException : BaseExceptions
    {
        public UserAlreadyExistException() : base("Kullanici zaten mevcut!")
        {

        }
    }
}
