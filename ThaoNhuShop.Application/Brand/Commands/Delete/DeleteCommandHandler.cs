using ErrorOr;
using MediatR;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using ThaoNhuShop.Domain.Common.Errors;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Brand.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, ErrorOr<Entity.Brand>>
    {
        private readonly IBrandRepository _brandRepository;

        public DeleteCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<ErrorOr<Entity.Brand>> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var response = await _brandRepository.DeleteBrandById(request.Id);

            if(response is null)
            {
                return BrandError.DeleteFail;
            }

            return response!;
        }
    }
}