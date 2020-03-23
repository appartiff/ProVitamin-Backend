using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IBrandService
    {
        Task<List<Brand>> Get();
        Task<Brand> Get(string title);
        Brand Create(Brand brand);
    }
}