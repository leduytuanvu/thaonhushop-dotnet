namespace ThaoNhuShop.Domain.Entities
{
    public class OrderDetail
    {
        public Guid Id { get; set; }

        public int Amount { get; set; } = new int();

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }


        public Product Product { get; set; } = new Product();

        public Order Order { get; set; } = new Order();
    }
}
