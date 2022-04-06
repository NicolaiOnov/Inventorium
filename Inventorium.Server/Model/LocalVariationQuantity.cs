namespace Inventorium.Server.Model
{
    public class LocalVariationQuantity
    {
        public int Id { get; set; }

        public Variation Variation { get; set; }
        public int VariationId { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }

        public int Quantity { get; set; }
    }
}
