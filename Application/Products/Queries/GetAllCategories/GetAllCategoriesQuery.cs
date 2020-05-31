using System.Collections.Generic;
using Domain.Entities;
using MediatR;

namespace Application.Products.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<List<Category>>
    {
        
    }
}