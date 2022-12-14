// using ErrorOr;
// using ThaoNhuShop.Application.Common.Interfaces.Authentication;
// using ThaoNhuShop.Application.Common.Interfaces.Persistence;
// using ThaoNhuShop.Application.Common.Interfaces.Services.Authentication.Common;
// using ThaoNhuShop.Domain.Common.Errors;

// namespace ThaoNhuShop.Application.Common.Interfaces.Services.Authentication.Queries
// {
//     public class AuthenticationQueryService : IAuthenticationQueryService
//     {
//         private readonly IUserRepository _userRepository;
//         private readonly IJwtTokenGenerator _jwtTokenGenerator;

//         public AuthenticationQueryService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
//         {
//             _jwtTokenGenerator = jwtTokenGenerator;
//             _userRepository = userRepository;
//         }

//         public async Task<ErrorOr<AuthenticationResult?>> Login(string phone, string password)
//         {
//             if(string.IsNullOrEmpty(phone)){
//                 return UserError.DuplicatePhone;
//             }

//             var user = await _userRepository.GetUserByPhoneAndPassword(phone: phone, password: password);

//             var token = _jwtTokenGenerator.GenerateToken(user!);
        
//             return new AuthenticationResult(
//                 Id: user!.Id,
//                 Phone: user.Phone,
//                 FullNName: user.FullName,
//                 Email: user.Email!,
//                 Avatar: user.Avatar!,
//                 Token: token
//             );
//         }
//     }
// }