namespace Inventorium.Server.Model
{
    public class Variation
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public long Sku { get; set; }
        public bool isDefault { get; set; }

        public ICollection<LocalVariationQuantity> LocalVariationQuantities { get; set; }
    }
}
