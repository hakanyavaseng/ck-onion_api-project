using MediatR;
using OnionAPI.Application.Interfaces.AutoMapper;
using OnionAPI.Application.Interfaces.UnitOfWorks;
using OnionAPI.Domain.Entities;

namespace OnionAPI.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQueryRequest, IList<GetAllBrandsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllBrandsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllBrandsQueryResponse>> Handle(GetAllBrandsQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = await unitOfWork.GetReadRepository<Brand>().GetAllAsync();
            return mapper.Map<GetAllBrandsQueryResponse,Brand>(brands);

        }

       
    }
}
