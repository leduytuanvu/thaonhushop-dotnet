using ErrorOr;
using MediatR;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Brand.Commands.Delete
{
    public record DeleteCommand
    (
        Guid Id
    ) : IRequest<ErrorOr<Entity.Brand>>;
}