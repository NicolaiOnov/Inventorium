using Inventorium.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace Inventorium.Server.Database
{
    public class InventoriumDbContext: DbContext
    {
        public InventoriumDbContext(DbContextOptions<InventoriumDbContext> options): base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Variation> Variations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocalVariationQuantity> LocalVariationQuantities { get; set; }
    }
}
