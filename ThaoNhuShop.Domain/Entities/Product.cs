namespace ThaoNhuShop.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public int Amount { get; set; } = new int();

        public double Price { get; set; } = new double();

        public double DiscountPercent { get; set; } = new double();

        public Guid BrandId { get; set; }

        public Guid CategoryId { get; set; }


        public Brand Brand { get; set; } = new Brand();

        public Category Category { get; set; } = new Category();

        public ICollection<ProductItem> ProductItems { get; set; } = new HashSet<ProductItem>();

        public ICollection<ProductImage> ProductImages { get; set; } = new HashSet<ProductImage>();
    }
}
