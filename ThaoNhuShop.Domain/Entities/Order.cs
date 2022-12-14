namespace ThaoNhuShop.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }

        public double Total { get; set; } = new double();

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? EstimatedDeliveryDate { get; set; }

        public string? Status { get; set; } = string.Empty;

        public Guid UserId { get; set; }


        public User User { get; set; } = new User();

        public ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();

    }
}
