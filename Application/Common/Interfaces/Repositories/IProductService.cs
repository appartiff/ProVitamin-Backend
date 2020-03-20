using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Application.Common.Interfaces.Repositories
{
    public interface IProductService
    {

        Task<List<Product>>  Get();
        Task<Product> Get(string id);
        Product Create(Product book);
        void Update(string id, Product bookIn);
        void Remove(Product bookIn);
        void Remove(string id);
      
    }
}