namespace ThaoNhuShop.Contract.Brand.Response
{
    public record BrandResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Logo { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;
    }
}