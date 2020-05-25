using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Application.Common.Interfaces.Repositories
{
    public interface IProductRepository
    {

        Task<List<Product>>  Get();
        Task<Product> Get(string id);
        Task<Product> Create(Product book, CancellationToken cancellationToken);
        void Update(string id, Product bookIn);
        void Remove(Product bookIn);
        void Remove(string id);
      
    }
}