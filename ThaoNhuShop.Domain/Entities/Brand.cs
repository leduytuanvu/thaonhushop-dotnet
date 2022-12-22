﻿namespace ThaoNhuShop.Domain.Entities
{
    public class Brand
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Logo { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;


        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
