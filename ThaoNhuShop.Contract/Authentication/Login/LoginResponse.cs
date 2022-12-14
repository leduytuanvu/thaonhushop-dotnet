namespace ThaoNhuShop.Contract.Authentication.Login
{
    public record LoginResponse
    (
        Guid Id,
        string Phone,   
        string FullName,
        string Email,
        string Avatar,     
        string Token
    );
}