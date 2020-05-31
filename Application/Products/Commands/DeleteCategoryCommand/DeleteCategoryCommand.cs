using Domain.Entities;
using MediatR;

namespace Application.Products.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommand : IRequest<string>
    {
        public Category Category { get; set; }
    }
}