using ErrorOr;
using MediatR;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Product.Queries.GetAll
{
    public record GetAllQuery
    (

    ) : IRequest<ErrorOr<List<Entity.Product>>>;
}