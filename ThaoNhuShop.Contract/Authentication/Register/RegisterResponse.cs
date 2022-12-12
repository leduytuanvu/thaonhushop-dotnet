namespace ThaoNhuShop.Contract.Authentication.Register
{
    public record RegisterResponse
    (
        Guid Id,
        string Phone,       
        string FullName
    );
}