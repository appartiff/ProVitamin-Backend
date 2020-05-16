using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> Get();
        Task<Category> Get(string title);
        Category Create(Category category);
        void Remove(string title);
    }
}