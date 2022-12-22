namespace ThaoNhuShop.Domain.Entities
{
    public class ProductItem
    {
        public Guid Id { get; set; }

        public string Color { get; set; } = string.Empty;

        public string Size { get; set; } = string.Empty;

        public int Amount { get; set; } = new int();

        public Guid ProductId { get; set; }


        public Product Product { get; set; } = new Product();
    }
}