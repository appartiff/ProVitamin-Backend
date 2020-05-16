using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IBrandRepository
    {
        Task<List<Brand>> Get();
        Task<Brand> Get(string title);
        Brand Create(Brand brand);
        void Remove(string title);
    }
}