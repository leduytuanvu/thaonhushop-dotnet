namespace ThaoNhuShop.Contract.Authentication.Register
{
    public record RegisterResponse
    (
        Guid Id,
        string Phone,   
        string FullName,
        string Email,
        string Avatar,     
        string Token
    );
}