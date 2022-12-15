using ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Application.Authentication.Common
{
    public record AuthenticationResult
    {
        public User User { get; set; } = new User();
        
        public string Token { get; set; } = string.Empty;
    }
}