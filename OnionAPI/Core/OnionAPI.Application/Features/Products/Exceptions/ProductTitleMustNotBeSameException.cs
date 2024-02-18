using OnionAPI.Application.Bases;

namespace OnionAPI.Application.Features.Products.Exceptions
{
    public class ProductTitleMustNotBeSameException : BaseExceptions
    {
        public ProductTitleMustNotBeSameException() : base("Urun basligi benzersiz olmalidir.") { }
       
    }
}
