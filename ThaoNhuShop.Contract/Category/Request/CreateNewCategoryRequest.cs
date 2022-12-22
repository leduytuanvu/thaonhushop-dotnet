namespace ThaoNhuShop.Contract.Category.Request
{
    public record CreateNewCategoryRequest
    {
        public string Name { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;
    }
}