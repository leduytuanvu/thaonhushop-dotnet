using FluentValidation;

namespace ThaoNhuShop.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator(){
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.RePassword).NotEmpty().WithMessage("RePassword is required");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("FullName is required");
        }
    }
}