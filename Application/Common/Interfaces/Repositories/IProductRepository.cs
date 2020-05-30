using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Application.Common.Interfaces.Repositories
{
    public interface IProductRepository
    {

        Task<List<Product>>  Get(CancellationToken cancellationToken);
        Task<Product> Get(string id, CancellationToken cancellationToken);
        Task<Product> Create(Product book, CancellationToken cancellationToken);
        Task<string> Update(Product productIn, CancellationToken cancellationToken);
        Task<string> Remove(Product product, CancellationToken cancellationToken);
        Task<string> Remove(string id, CancellationToken cancellationToken);
      
    }
}