namespace Inventorium.Server.Model
{
    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<LocalVariationQuantity> LocalVariationQuantities { get; set; }
    }
}
