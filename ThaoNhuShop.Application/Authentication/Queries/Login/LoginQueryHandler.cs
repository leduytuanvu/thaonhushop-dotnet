using ErrorOr;
using MediatR;
using ThaoNhuShop.Application.Common.Interfaces.Authentication;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using ThaoNhuShop.Application.Authentication.Common;
using ThaoNhuShop.Domain.Common.Errors;

namespace ThaoNhuShop.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {

         private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(query.Phone)){
                return UserError.DuplicatePhone;
            }

            var user = await _userRepository.GetUserByPhoneAndPassword(phone: query.Phone, password: query.Password);

            var token = _jwtTokenGenerator.GenerateToken(user!);
        
            return new AuthenticationResult {
                User = user!,
                Token = token
            };
        }
    }
}