// using ErrorOr;
// using MediatR;
// using ThaoNhuShop.Application.Common.Interfaces.Persistence;
// using Entity = ThaoNhuShop.Domain.Entities;

// namespace ThaoNhuShop.Application.Address.Commands.GetById
// {
//     public class GetByIdCommandHandler : IRequestHandler<GetByIdCommand, ErrorOr<Entity.Address>>
//     {
//         private readonly IAddressRepository _addressRepository;

//         public GetByIdCommandHandler(IAddressRepository addressRepository)
//         {
//             _addressRepository = addressRepository;
//         }

//         public Task<ErrorOr<Entity.Address>> Handle(GetByIdCommand request, CancellationToken cancellationToken)
//         {
            
//         }
//     }
// }