using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces.Repositories;
using Domain.Entities.Product;
using MediatR;

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            
        }
        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product()
            {
                Sku = request.Sku,
                Details = request.Details,
                Pricing = request.Pricing,
                Shipping = request.Shipping
            };
            await _productRepository.Create(entity,cancellationToken);
            return entity.Id;
        }
    }
}