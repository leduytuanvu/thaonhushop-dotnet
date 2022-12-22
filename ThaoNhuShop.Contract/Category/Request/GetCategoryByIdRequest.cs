namespace ThaoNhuShop.Contract.Category.Request
{
    public record GetCategoryByIdRequest
    {
        public Guid Id { get; set; }
    }
}