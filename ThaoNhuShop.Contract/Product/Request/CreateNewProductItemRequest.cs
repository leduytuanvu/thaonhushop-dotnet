namespace ThaoNhuShop.Contract.Product.Request
{
    public class CreateNewProductItemRequest
    {
        public Guid Id { get; set; }

        public string Color { get; set; } = string.Empty;

        public string Size { get; set; } = string.Empty;

        public int Amount { get; set; } = new int();

        public Guid ProductId { get; set; }
    }
}