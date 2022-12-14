namespace ThaoNhuShop.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Phone { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? Avatar { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        
        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}