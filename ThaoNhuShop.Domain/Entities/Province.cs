namespace ThaoNhuShop.Domain.Entities
{
    public class Province
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int PostCode { get; set; } = new int();


        public ICollection<District> Districts { get; set; } = new HashSet<District>();
    }
}
