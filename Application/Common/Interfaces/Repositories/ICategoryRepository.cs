using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> Get();
        Task<Category> Get(string id);
        Task<Category> Create(Category category);
        Task<Category> Remove(Category category);
    }
}