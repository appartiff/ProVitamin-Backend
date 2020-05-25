using Domain.Entities.Product;
using MediatR;

namespace Application.Products.Queries.GetProduct
{
    public class GetProductQuery :IRequest<Product>
    {
        public string Id { get; set; }
    }
}