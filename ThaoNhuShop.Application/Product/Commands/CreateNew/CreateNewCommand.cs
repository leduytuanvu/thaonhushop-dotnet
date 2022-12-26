using ErrorOr;
using MediatR;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Product.Commands.CreateNew
{
    public record CreateNewCommand
    (
        Entity.Product Product,
        List<Entity.ProductImage> ListProductImage,
        List<Entity.ProductItem> ListProductItem
    ) : IRequest<ErrorOr<Entity.Product>>;
}