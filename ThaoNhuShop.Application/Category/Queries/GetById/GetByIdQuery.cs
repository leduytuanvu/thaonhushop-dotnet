using ErrorOr;
using MediatR;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Category.Queries.GetById
{
    public record GetByIdQuery
    (
        Guid Id
    ) : IRequest<ErrorOr<Entity.Category>>;
}