using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces.Repositories;
using Domain.Entities.Product;
using MediatR;

namespace Application.Products.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, string>
    {  
        private IProductRepository _productRepository;
        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
           await _productRepository.Update(request.Product, cancellationToken);
           return request.Product.Id;
        }
    }
}