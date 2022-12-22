namespace ThaoNhuShop.Contract.Category.Response
{
    public record CategoryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;
    }
}