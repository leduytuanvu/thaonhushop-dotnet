// using ErrorOr;
// using MediatR;
// using Entity = ThaoNhuShop.Domain.Entities;

// namespace ThaoNhuShop.Application.Address.Commands.Create
// {
//     public record CreateCommand
//     (
//         string FullName,
//         string PhoneContact,
//         string? Description,
//         bool IsDefault,
//         Guid UserId
//     ) : IRequest<ErrorOr<Entity.Address>>;
// }