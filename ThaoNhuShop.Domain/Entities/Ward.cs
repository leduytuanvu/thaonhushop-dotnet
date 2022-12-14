namespace ThaoNhuShop.Domain.Entities
{
    public class Ward
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int DistrictId { get; set; }


        public District District { get; set; } = new District();
    }
}
