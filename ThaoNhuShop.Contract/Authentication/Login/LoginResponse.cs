namespace ThaoNhuShop.Contract.Authentication.Login
{
    public record LoginResponse
    {
        public Guid Id { get; set; }

        public string Phone { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Avatar { get; set; } = string.Empty;  
        
        public string Token { get; set; } = string.Empty;
    }
}