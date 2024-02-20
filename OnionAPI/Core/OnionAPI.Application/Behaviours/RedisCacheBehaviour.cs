using MediatR;
using OnionAPI.Application.Interfaces.RedisCache;

namespace OnionAPI.Application.Behaviours
{
    public class RedisCacheBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IRedisCacheService redisCacheService;

        public RedisCacheBehaviour(IRedisCacheService redisCacheService)
        {
            this.redisCacheService = redisCacheService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(request is ICacheableQuery query)
            {
                string? cacheKey = query.CacheKey;
                double cacheTime = query.CacheTime;

                TResponse cachedData = await redisCacheService.GetAsync<TResponse>(cacheKey);
                if(cachedData is not null)
                    return cachedData;

                TResponse response = await next();

                if (response is not null)
                    await redisCacheService.SetAsync(cacheKey, response, DateTime.Now.AddMinutes(cacheTime));

                return response;
            }
            
            return await next();
        }
    }
}
