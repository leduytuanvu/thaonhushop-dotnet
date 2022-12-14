using ErrorOr;
using MediatR;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Address.Commands.SetDefault
{
    public class SetDefaultCommandHandler : IRequestHandler<SetDefaultCommand, ErrorOr<Entity.Address>>
    {
        private readonly IAddressRepository _addressRepository;

        public SetDefaultCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<ErrorOr<Entity.Address>> Handle(SetDefaultCommand request, CancellationToken cancellationToken)
        {
            var response = await _addressRepository!.SetAddressIsDefault(request.Id);
            return response!;
        }
    }
}