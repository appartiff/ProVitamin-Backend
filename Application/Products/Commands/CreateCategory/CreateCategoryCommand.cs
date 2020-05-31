using Domain.Entities;
using MediatR;

namespace Application.Products.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<string>
    {
        public string Category { get; set; }
    }
}