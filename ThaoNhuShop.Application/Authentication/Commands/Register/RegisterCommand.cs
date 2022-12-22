using ErrorOr;
using MediatR;
using ThaoNhuShop.Application.Authentication.Common;

namespace ThaoNhuShop.Application.Authentication.Commands.Register
{
    public record RegisterCommand
    (
        string Phone,
        string Password,
        string RePassword
    ) : IRequest<ErrorOr<AuthenticationResult>>;
}