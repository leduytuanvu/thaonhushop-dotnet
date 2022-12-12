namespace ThaoNhuShop.Contract.Authentication.Register
{
    public record RegisterRequest
    (
        string Phone,
        string Password,
        string RePassword,
        string FullName
    );
}