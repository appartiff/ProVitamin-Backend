using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Products.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, string>
    {
        private ICategoryRepository _categoryRepository;
        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<string> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var results = await _categoryRepository.Remove(request.Category);
            return results.Id;
        }
    }
}