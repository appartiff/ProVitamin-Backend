using System.Collections.Generic;
using Domain.Entities.Product;
using MediatR;

namespace Application.Products.Queries
{
    public class GetAllProductsQuery  : IRequest<List<Product>>
    {
        public GetAllProductsQuery() {
        }
    }
}