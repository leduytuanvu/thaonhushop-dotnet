namespace ThaoNhuShop.Contract.Authentication.Register
{
    public record RegisterRequest
    {
        public string Phone { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string RePassword { get; set; } = string.Empty;  

        public string FullName { get; set; } = string.Empty;
        
    }
}