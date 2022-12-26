namespace ThaoNhuShop.Contract.Product.Response
{
    public class ProductResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public int Amount { get; set; } = new int();

        public double Price { get; set; } = new double();

        public double DiscountPercent { get; set; } = new double();

        public Guid BrandId { get; set; }

        public Guid CategoryId { get; set; }

    }
}