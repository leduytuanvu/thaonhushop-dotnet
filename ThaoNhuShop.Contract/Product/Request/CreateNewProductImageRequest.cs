namespace ThaoNhuShop.Contract.Product.Request
{
    public class CreateNewProductImageRequest
    {
        public Guid Id { get; set; }

        public string Url { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public Guid ProductId { get; set; }
    }
}