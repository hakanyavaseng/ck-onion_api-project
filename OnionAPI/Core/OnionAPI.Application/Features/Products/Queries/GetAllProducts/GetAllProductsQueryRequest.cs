using MediatR;
using OnionAPI.Application.Interfaces.RedisCache;

namespace OnionAPI.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllProducts";
        public double CacheTime => 60;
    }
}
