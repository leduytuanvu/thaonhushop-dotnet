namespace ThaoNhuShop.Domain.Entities
{
    public class Address
    {
        public Guid Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string PhoneContact { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public bool IsDefault { get; set; } = false;

        public Guid UserId { get; set; }


        public User User { get; set; } = new User();
    }
}
