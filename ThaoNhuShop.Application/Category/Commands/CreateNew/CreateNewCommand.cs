using Entity = ThaoNhuShop.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ThaoNhuShop.Application.Category.Commands.CreateNew
{
    public record CreateNewCommand
    (
        string Name,
        string Image
    ) : IRequest<ErrorOr<Entity.Category>>;
}