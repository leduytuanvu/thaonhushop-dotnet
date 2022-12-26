using ErrorOr;
using MediatR;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Address.Commands.SetDefault
{
    public record SetDefaultCommand
    (
        Guid Id
    ) : IRequest<ErrorOr<Entity.Address>>;
}