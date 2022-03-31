namespace Inventorium.Server.Model
{
    public class Variation
    {
        public int VariationId { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Sku { get; set; }
        public bool isDefault { get; set; }

        public ICollection<LocalVariationQuantity> LocalVariationQuantities { get; set; }
    }
}
