using ErrorOr;
using MediatR;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using ThaoNhuShop.Domain.Common.Errors;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Brand.Commands.CreateNew
{
    public class CreateNewCommandHandler : IRequestHandler<CreateNewCommand, ErrorOr<Entity.Brand>>
    {
        private readonly IBrandRepository _brandRepository;

        public CreateNewCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<ErrorOr<Entity.Brand>> Handle(CreateNewCommand command, CancellationToken cancellationToken)
        {
            var brand = new Entity.Brand();
            brand.Name = command.Name;
            brand.Logo = command.Logo;
            brand.Description = command.Description;
            var response = await _brandRepository.CreateNewBrand(brand);

            if(response is null)
            {
                return BrandError.CreateNewFail;
            }

            return response;
        }
    }
}