namespace Inventorium.Server.Model
{
    public class LocalVariationQuantity
    {
        public int LocalVariationQuantityId { get; set; }

        public int VariationId { get; set; }
        public int LocationId { get; set; }

        public int Quantity { get; set; }
    }
}
