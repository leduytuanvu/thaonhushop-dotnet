using ErrorOr;
using MediatR;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Product.Commands.CreateNew
{
    public class CreateNewCommandHandler : IRequestHandler<CreateNewCommand, ErrorOr<Entity.Product>>
    {
        private readonly IProductRepository _productRepository;

        public CreateNewCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ErrorOr<Entity.Product>> Handle(CreateNewCommand request, CancellationToken cancellationToken)
        {
            var product = new Entity.Product();
            var response = await _productRepository!.CreateNewProduct(product);
            return response!;
        }
    }
}