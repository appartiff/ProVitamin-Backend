using Domain.Entities.Product;
using MediatR;

namespace Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<string>
    {
        public Product Product { get; set; }
    }
}