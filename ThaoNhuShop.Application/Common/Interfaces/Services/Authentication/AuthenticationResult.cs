namespace ThaoNhuShop.Application.Common.Interfaces.Services.Authentication
{
    public record AuthenticationResult
    (
         Guid Id ,
         string Phone,
         string FullNName,
         string Token
    ) ;
}