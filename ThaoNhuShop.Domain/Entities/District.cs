namespace ThaoNhuShop.Domain.Entities
{
    public class District
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int ProvinceId { get; set; }


        public Province Province { get; set; } = new Province();

        public ICollection<Ward> Wards { get; set; } = new HashSet<Ward>();
    }
}
