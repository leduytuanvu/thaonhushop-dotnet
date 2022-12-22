using Entity = ThaoNhuShop.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ThaoNhuShop.Application.Brand.Queries.GetAll
{
    public record GetAllQuery
    (

    ) : IRequest<ErrorOr<List<Entity.Brand>>>;
}