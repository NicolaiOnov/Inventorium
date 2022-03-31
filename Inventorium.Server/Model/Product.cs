namespace Inventorium.Server.Model
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public ICollection<Variation> Variations { get; set; }
    }
}
