using Entity = ThaoNhuShop.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ThaoNhuShop.Application.Brand.Commands.CreateNew
{
    public record CreateNewCommand
    (
        string Name,
        string Logo,
        string Description
    ) : IRequest<ErrorOr<Entity.Brand>>;
}