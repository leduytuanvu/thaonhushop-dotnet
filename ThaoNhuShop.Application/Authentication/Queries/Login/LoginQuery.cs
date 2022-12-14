using ErrorOr;
using MediatR;
using ThaoNhuShop.Application.Authentication.Common;

namespace ThaoNhuShop.Application.Authentication.Queries.Login
{
    public record LoginQuery
    (
        string Phone,
        string Password
    ) : IRequest<ErrorOr<AuthenticationResult>>;
}