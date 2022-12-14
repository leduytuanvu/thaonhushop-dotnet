namespace ThaoNhuShop.Contract.Authentication.Login
{
    public record LoginRequest
    (
        string Phone,       
        string Password
    );
}