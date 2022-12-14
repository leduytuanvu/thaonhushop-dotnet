namespace ThaoNhuShop.Domain.Entities
{
    public class Color
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public Guid ProductId { get; set; }


        public Product Product { get; set; } = new Product();
    }
}
