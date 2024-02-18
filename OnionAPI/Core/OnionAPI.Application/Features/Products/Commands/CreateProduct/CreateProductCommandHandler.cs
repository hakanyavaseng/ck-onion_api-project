using MediatR;
using OnionAPI.Application.Interfaces.UnitOfWorks;
using OnionAPI.Domain.Entities;

namespace OnionAPI.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
    {
        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork _unitOfWork { get; }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);

            await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);


            if (await _unitOfWork.SaveAsync() > 0) // That means product added successfully.
            {
                foreach (var categoryId in request.CategoryIds) // Adding product's id and its categories to ProductCategory table.
                    await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId
                    });
                await _unitOfWork.SaveAsync();  // Save changes on ProductCategory
            }

            return Unit.Value;
        }
    }
}
