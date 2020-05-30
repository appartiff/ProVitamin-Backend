using MediatR;

namespace Application.Products.Queries.GetIsSkuExists
{
    public class GetIsSkuExistsQuery : IRequest<bool>
    {
        public string Sku { get; set; }
    }
}