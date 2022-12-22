// using ErrorOr;
// using MediatR;
// using ThaoNhuShop.Application.Common.Interfaces.Persistence;
// using Entity = ThaoNhuShop.Domain.Entities;

// namespace ThaoNhuShop.Application.Address.Queries.GetAll
// {
//     public class GetAllQueryHandler : IRequestHandler<GetAllQuery, ErrorOr<List<Entity.Address>>>
//     {
//         private readonly IAddressRepository _addressRepository;

//         public GetAllQueryHandler(IAddressRepository addressRepository)
//         {
//             _addressRepository = addressRepository;
//         }

//         public async Task<ErrorOr<List<Entity.Address>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
//         {
//             var response = await _addressRepository!.GetAllAddressByUserId(request.Id);

//             return response;
//         }
//     }
// }