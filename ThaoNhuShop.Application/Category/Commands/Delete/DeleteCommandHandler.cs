using ErrorOr;
using MediatR;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using ThaoNhuShop.Domain.Common.Errors;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Category.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, ErrorOr<Entity.Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<Entity.Category>> Handle(DeleteCommand command, CancellationToken cancellationToken)
        {
            var response = await _categoryRepository.DeleteCategoryById(command.Id);

            if(response is null)
            {
                return CategoryError.DeleteFail;
            }

            return response!;
        }
    }
}