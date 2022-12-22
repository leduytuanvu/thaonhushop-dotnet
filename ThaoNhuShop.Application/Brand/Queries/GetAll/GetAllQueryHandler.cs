using ErrorOr;
using MediatR;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using ThaoNhuShop.Domain.Common.Errors;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Brand.Queries.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, ErrorOr<List<Entity.Brand>>>
    {
        private readonly IBrandRepository _brandRepository;

        public GetAllQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<ErrorOr<List<Entity.Brand>>> Handle(GetAllQuery query, CancellationToken cancellationToken)
        {
            var response = await _brandRepository!.GetAllBrand();

            if(response is null)
            {
                return BrandError.CreateNewFail;
            }

            return response!;
        }
    }
}