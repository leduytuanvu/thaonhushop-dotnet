namespace ThaoNhuShop.Domain.Entities
{
    public class ProductImage
    {
        public Guid Id { get; set; }

        public string Url { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public Guid ProductId { get; set; }


        public Product Product { get; set; } = new Product();
    }
}
