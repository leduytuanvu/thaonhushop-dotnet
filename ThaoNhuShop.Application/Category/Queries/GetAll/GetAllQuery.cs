
using ErrorOr;
using MediatR;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Category.Queries.GetAll
{
    public record GetAllQuery
    (

    ) : IRequest<ErrorOr<List<Entity.Category>>>;
}