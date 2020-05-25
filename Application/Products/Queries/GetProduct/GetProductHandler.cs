using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces.Repositories;
using Domain.Entities.Product;
using MediatR;

namespace Application.Products.Queries.GetProduct
{
    public class GetProductHandler: IRequestHandler<GetProductQuery, Product>
    {
        private readonly IProductRepository _productRepository;
        public GetProductHandler( IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.Id);
            if (product == null)
                throw new NotFoundException(nameof(product), request);
            return product;
        }
    }
}