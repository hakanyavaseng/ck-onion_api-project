using OnionAPI.Application.Bases;
using OnionAPI.Application.Features.Products.Exceptions;
using OnionAPI.Domain.Entities;

namespace OnionAPI.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(Product? isExistProduct)
        {
            if (isExistProduct!= null) throw new ProductTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
