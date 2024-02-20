using MediatR;
using OnionAPI.Application.Interfaces.RedisCache;

namespace OnionAPI.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandRequest : IRequest<Unit>
    {
        public string Name { get; set; }

       
    }
}
