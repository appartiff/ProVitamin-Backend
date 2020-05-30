using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> Get();
        Task<Category> Get(string id);
        Category Create(Category category);
        void Remove(string id);
    }
}