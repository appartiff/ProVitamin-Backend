using System.Collections.Generic;
using Domain.Entities.Product;
using MediatR;

namespace Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery  : IRequest<List<Product>>
    {
        public GetAllProductsQuery() {
        }
    }
}