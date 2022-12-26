using Entity = ThaoNhuShop.Domain.Entities;
using MediatR;
using ErrorOr;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;

namespace ThaoNhuShop.Application.Address.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, ErrorOr<Entity.Address>>
    {
        private readonly IAddressRepository _addressRepository;

        public DeleteCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<ErrorOr<Entity.Address>> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var response = await _addressRepository!.DeleteAddressById(request.Id);
            return response!;
        }
    }
}