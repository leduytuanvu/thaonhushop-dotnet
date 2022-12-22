using FluentValidation;

namespace ThaoNhuShop.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator(){
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone number must be not empty");
            RuleFor(x => x.Phone).Must(x => x.Length > 9 && x.Length < 12).WithMessage("Format phone number wrong");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password must be not empty");
            RuleFor(x => x.Password).Must(x => x.Length > 4).WithMessage("Password must have more than 5 letters");
            RuleFor(x => x.RePassword).NotEmpty().WithMessage("Re-password must be not empty");
        }
    }
}