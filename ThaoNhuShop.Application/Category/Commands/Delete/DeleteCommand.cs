using Entity = ThaoNhuShop.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ThaoNhuShop.Application.Category.Commands.Delete
{
    public record DeleteCommand
    (
        Guid Id
    ) : IRequest<ErrorOr<Entity.Category>>;
}