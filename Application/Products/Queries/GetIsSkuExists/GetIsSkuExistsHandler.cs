using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces.Repositories;
using MediatR;

namespace Application.Products.Queries.GetIsSkuExists
{
    public class GetIsSkuExistsHandler : IRequestHandler<GetIsSkuExistsQuery, bool>
    {
        private IProductRepository _productRepository;
        public GetIsSkuExistsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(GetIsSkuExistsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetSku(request.Sku, cancellationToken);
        }
    }
}