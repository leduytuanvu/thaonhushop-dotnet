namespace ThaoNhuShop.Application.Common.Interfaces.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationResult Login(string phone, string password)
        {
            return new AuthenticationResult(
                Id: Guid.NewGuid(),
                Phone: phone,
                FullNName: "LE DUY TUAN VU",
                Token: "TOKEN"
            );
        }

        public AuthenticationResult Register(string phone, string password, string rePassword, string fullName)
        {
            return new AuthenticationResult(
                Id: Guid.NewGuid(),
                Phone: phone,
                FullNName: "LE DUY TUAN VU",
                Token: "TOKEN"
            );
        }
    }
}