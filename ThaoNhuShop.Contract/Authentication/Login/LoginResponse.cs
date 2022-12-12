namespace ThaoNhuShop.Contract.Authentication.Login
{
    public record LoginResponse
    (
        Guid Id,
        string Phone,       
        string FullName
    );
}