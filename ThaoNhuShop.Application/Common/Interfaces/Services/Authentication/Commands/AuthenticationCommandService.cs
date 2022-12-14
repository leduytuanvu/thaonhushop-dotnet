// using ErrorOr;
// using ThaoNhuShop.Application.Common.Interfaces.Authentication;
// using ThaoNhuShop.Application.Common.Interfaces.Persistence;
// using ThaoNhuShop.Application.Common.Interfaces.Services.Authentication.Common;
// using ThaoNhuShop.Domain.Common.Errors;

// namespace ThaoNhuShop.Application.Common.Interfaces.Services.Authentication.Commands
// {
//     public class AuthenticationCommandService : IAuthenticationCommandService
//     {
//         private readonly IUserRepository _userRepository;
//         private readonly IJwtTokenGenerator _jwtTokenGenerator;

//         public AuthenticationCommandService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
//         {
//             _jwtTokenGenerator = jwtTokenGenerator;
//             _userRepository = userRepository;
//         }

//         public async Task<ErrorOr<AuthenticationResult?>> Register(string phone, string password, string rePassword, string fullName)
//         {
//             var checkPhoneExistOrNot = await _userRepository.GetUserByPhone(phone);

//             if (checkPhoneExistOrNot != null)
//             {
//                 return UserError.DuplicatePhone;
//             }
//             var result = await _userRepository.CreateUser(phone, password, fullName);

//             var token = _jwtTokenGenerator.GenerateToken(result!);
        
//             return new AuthenticationResult(
//                 Id: result!.Id,
//                 Phone: result.Phone,
//                 FullNName: result.FullName,
//                 Email: result.Email!,
//                 Avatar: result.Avatar!,
//                 Token: token
//             );
//         }
//     }
// }