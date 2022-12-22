namespace ThaoNhuShop.Contract.Authentication.Request
{
    public record LoginRequest
    {
        public string Phone { get; set; } = string.Empty;  
         
        public string Password { get; set; } = string.Empty;
    }
}