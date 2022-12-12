namespace ThaoNhuShop.Application.Common.Interfaces.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string phone, string password);

        AuthenticationResult Register(string phone, string password, string rePassword, string fullName);
    }
}