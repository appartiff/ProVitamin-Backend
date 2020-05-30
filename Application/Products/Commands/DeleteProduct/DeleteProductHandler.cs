using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces.Repositories;
using MediatR;

namespace Application.Products.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, string>
    {
        private IProductRepository _productRepository;
        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            await _productRepository.Remove(request.Id,cancellationToken);
            throw new System.NotImplementedException();
        }
    }
}