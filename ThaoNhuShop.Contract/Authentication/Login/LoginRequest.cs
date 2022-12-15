namespace ThaoNhuShop.Contract.Authentication.Login
{
    public record LoginRequest
    {
        public string Phone { get; set; } = string.Empty;   
         
        public string Password { get; set; } = string.Empty;
    }
}