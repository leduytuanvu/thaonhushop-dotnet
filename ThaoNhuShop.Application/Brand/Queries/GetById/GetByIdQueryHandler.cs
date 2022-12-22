using Entity = ThaoNhuShop.Domain.Entities;
using ErrorOr;
using MediatR;
using ThaoNhuShop.Domain.Common.Errors;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;

namespace ThaoNhuShop.Application.Brand.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, ErrorOr<Entity.Brand>>
    {
        private readonly IBrandRepository _brandRepository;

        public GetByIdQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<ErrorOr<Entity.Brand>> Handle(GetByIdQuery query, CancellationToken cancellationToken)
        {
            var response = await _brandRepository!.GetBrandById(query.Id);

            if(response is null)
            {
                return BrandError.NotFoundBrand;
            }

            return response!;
        }
    }
}