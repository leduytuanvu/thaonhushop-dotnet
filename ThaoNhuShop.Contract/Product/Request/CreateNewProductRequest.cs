namespace ThaoNhuShop.Contract.Product.Request
{
    public class CreateNewProductRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public int Amount { get; set; } = new int();

        public double Price { get; set; } = new double();

        public double DiscountPercent { get; set; } = new double();

        public Guid BrandId { get; set; }

        public Guid CategoryId { get; set; }

        public ICollection<CreateNewProductItemRequest> ProductItems { get; set; } = new HashSet<CreateNewProductItemRequest>();

        public ICollection<CreateNewProductImageRequest> ProductImages { get; set; } = new HashSet<CreateNewProductImageRequest>();
    }
}