using ErrorOr;
using MediatR;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Product.Queries.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, ErrorOr<List<Entity.Product>>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ErrorOr<List<Entity.Product>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var response = await _productRepository!.GetAllProduct();
            return response!;
        }
    }
}