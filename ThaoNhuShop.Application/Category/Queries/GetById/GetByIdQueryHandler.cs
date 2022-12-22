using ErrorOr;
using MediatR;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using ThaoNhuShop.Domain.Common.Errors;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Category.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, ErrorOr<Entity.Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<Entity.Category>> Handle(GetByIdQuery query, CancellationToken cancellationToken)
        {
            var response = await _categoryRepository.GetCategoryById(query.Id);

            if(response is null)
            {
                return CategoryError.NotFoundCategory;
            }

            return response!;
        }
    }
}