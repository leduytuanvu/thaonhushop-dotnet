using FluentValidation;
using ThaoNhuShop.Application.Authentication.Queries.Login;

namespace ThaoNhuShop.Application.Authentication.Commands.Register
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator(){
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}