using Entity = ThaoNhuShop.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ThaoNhuShop.Application.Brand.Queries.GetById
{
    public record GetByIdQuery
    (
        Guid Id
    ) : IRequest<ErrorOr<Entity.Brand>>;
}