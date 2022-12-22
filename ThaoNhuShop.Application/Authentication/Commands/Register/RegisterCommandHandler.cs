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

            if (checkPhoneExistOrNot is not null)
            {
                return AuthenticationError.DuplicatePhone;
            } 
            
            if(!command.Password.Equals(command.RePassword))
            {
                return AuthenticationError.PasswordNotMatch;
            }

            var user = await _userRepository.CreateNewUser(command.Phone, command.Password);

            if(user is null)
            {
                return AuthenticationError.CreateUserFail;
            }

            var token = _jwtTokenGenerator.GenerateToken(user!);

            if(string.IsNullOrEmpty(token))
            {
                return AuthenticationError.GenerateTokenFail;
            }
        
            return new AuthenticationResult {
                User = user!,
                Token = token
            };
        }
    }
}