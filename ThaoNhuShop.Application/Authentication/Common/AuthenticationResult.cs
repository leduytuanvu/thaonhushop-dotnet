using ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Authentication.Common
{
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}