using ErrorOr;
using MediatR;
using Entity = ThaoNhuShop.Domain.Entities;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;

namespace ThaoNhuShop.Application.Category.Queries.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, ErrorOr<List<Entity.Category>>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<List<Entity.Category>>> Handle(GetAllQuery query, CancellationToken cancellationToken)
        {
            var response = await _categoryRepository.GetAllCategory();

            // if(response is null){
            //     return CategoryError.NotFoundCategory;
            // }

            return response!;
        }
    }
}