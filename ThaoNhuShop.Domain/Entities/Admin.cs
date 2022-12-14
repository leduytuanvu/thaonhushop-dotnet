namespace ThaoNhuShop.Domain.Entities
{
    public class Admin
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Phone { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;
    }
}
