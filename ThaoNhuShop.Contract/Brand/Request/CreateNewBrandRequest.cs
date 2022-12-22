namespace ThaoNhuShop.Contract.Brand.Request
{
    public class CreateNewBrandRequest
    {
        public string Name { get; set; } = string.Empty;

        public string Logo { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;
    }
}