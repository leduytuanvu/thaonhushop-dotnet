using ErrorOr;
using MediatR;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Address.Commands.Update
{
    public record UpdateCommand
    (
        Guid Id,
        Entity.Address Address
    ) : IRequest<ErrorOr<Entity.Address>>;
}