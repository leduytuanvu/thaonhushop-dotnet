// using ErrorOr;
// using MediatR;
// using ThaoNhuShop.Application.Common.Interfaces.Persistence;
// using Entity = ThaoNhuShop.Domain.Entities;

// namespace ThaoNhuShop.Application.Address.Commands.Update
// {
//     public class UpdateCommandHandler : IRequestHandler<UpdateCommand, ErrorOr<Entity.Address>>
//     {
//         private readonly IAddressRepository _addressRepository;

//         public UpdateCommandHandler(IAddressRepository addressRepository)
//         {
//             _addressRepository = addressRepository;
//         }

//         public Task<ErrorOr<Entity.Address>> Handle(UpdateCommand request, CancellationToken cancellationToken)
//         {
            
//         }
//     }
// }