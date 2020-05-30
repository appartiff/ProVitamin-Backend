using Domain.Entities.Product;
using MediatR;

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<string>
    {
        public string Sku { get; set; }
        public ProductPricing Pricing { get; set; }
        public ProductDetails Details { get; set; }
        public ProductShipping Shipping { get; set; }
    }
}