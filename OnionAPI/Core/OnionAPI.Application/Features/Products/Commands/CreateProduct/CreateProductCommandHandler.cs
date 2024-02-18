using MediatR;
using OnionAPI.Application.Features.Products.Exceptions;
using OnionAPI.Application.Features.Products.Rules;
using OnionAPI.Application.Interfaces.UnitOfWorks;
using OnionAPI.Domain.Entities;

namespace OnionAPI.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly ProductRules productRules = new();

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, ProductRules productRules)
        {
            _unitOfWork = unitOfWork;
            this.productRules = productRules;
        }

        public IUnitOfWork _unitOfWork { get; }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product isExistProduct = await _unitOfWork.GetReadRepository<Product>().GetAsync(p => p.Title == request.Title);
            
            //Check if any product exist with same title.
            await productRules.ProductTitleMustNotBeSame(isExistProduct);


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
