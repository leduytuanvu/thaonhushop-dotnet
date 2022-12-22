using ErrorOr;
using MediatR;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using ThaoNhuShop.Domain.Common.Errors;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Category.Commands.CreateNew
{
    public class CreateNewCommandHandler : IRequestHandler<CreateNewCommand, ErrorOr<Entity.Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateNewCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<Entity.Category>> Handle(CreateNewCommand command, CancellationToken cancellationToken)
        {
            var category = new Entity.Category();
            category.Name = command.Name;
            category.Image = command.Image;
            var response = await _categoryRepository.CreateNewCategory(category);

            if(response is null)
            {
                return CategoryError.CreateNewFail;
            }

            return response!;
        }
    }
}