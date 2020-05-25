using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces.Repositories;
using Domain.Entities.Product;
using MediatR;

namespace Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IProductRepository _productRepository;
        
        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            
        }
        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get();
            if (product == null)
                throw new NotFoundException(nameof(product), request);
            return product;
        }
    }
}