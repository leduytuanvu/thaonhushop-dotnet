using ErrorOr;
using MediatR;
using ThaoNhuShop.Application.Common.Interfaces.Authentication;
using ThaoNhuShop.Application.Authentication.Common;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using ThaoNhuShop.Domain.Common.Errors;

namespace ThaoNhuShop.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {

        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var checkPhoneExistOrNot = await _userRepository.GetUserByPhone(command.Phone);

            if (checkPhoneExistOrNot != null)
            {
                return UserError.DuplicatePhone;
            }
            var user = await _userRepository.CreateUser(command.Phone, command.Password, command.FullName);

            var token = _jwtTokenGenerator.GenerateToken(user!);
        
            return new AuthenticationResult(
                User: user!,
                Token: token
            );
        }
    }
}