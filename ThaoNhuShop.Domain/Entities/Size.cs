namespace ThaoNhuShop.Domain.Entities
{
    public class Size
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public Guid ProductId { get; set; }


        public Product Product { get; set; } = new Product();
    }
}
