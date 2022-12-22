// using ErrorOr;
// using MediatR;
// using ThaoNhuShop.Application.Common.Interfaces.Persistence;
// using Entity = ThaoNhuShop.Domain.Entities;

// namespace ThaoNhuShop.Application.Address.Commands.Create
// {
//     public class CreateCommandHandler : IRequestHandler<CreateCommand, ErrorOr<Entity.Address>>
//     {
//         private readonly IAddressRepository _addressRepository;

//         public CreateCommandHandler(IAddressRepository addressRepository)
//         {
//             _addressRepository = addressRepository;
//         }

//         public async Task<ErrorOr<Entity.Address>> Handle(CreateCommand request, CancellationToken cancellationToken)
//         {
//             var address = new Entity.Address();
//             address.FullName = request.FullName;
//             address.PhoneContact = request.PhoneContact;
//             address.Description = request.Description;
//             address.IsDefault = request.IsDefault;
//             address.UserId = request.UserId;
//             var response = await _addressRepository!.CreateNewAddress(address);
//             return response!;
//         }
//     }
// }