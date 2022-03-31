using Inventorium.Server.Database;
using Inventorium.Server.Model;

namespace Inventorium.Server.Services.DbInitializer
{
    public class DbInitializerService : IDbInitializerService
    {
        private readonly InventoriumDbContext _dbContext;

        public DbInitializerService(
            InventoriumDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize(bool recreateDb)
        {
            if (!recreateDb)
                return;

            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            GenerateProducts().ToList() 
                .ForEach(i => _dbContext.Products.Add(i));
            _dbContext.SaveChanges();

            GenerateLocations().ToList()
                .ForEach(i => _dbContext.Locations.Add(i));
            _dbContext.SaveChanges();

            GenerateLocalVariationQuantities().ToList()
                .ForEach(i => _dbContext.LocalVariationQuantities.Add(i));
            _dbContext.SaveChanges();
        }

        private IEnumerable<Product> GenerateProducts()
        {
            return new[]
            {
                new Product { 
                    Name = "Alize Puffy Fine", 
                    Price = 66,
                    Variations = new List<Variation>
                    {
                        new() { Name = "62 - black", Price = 0, isDefault = false, Sku = 41204127099},
                        new() { Name = "02 - white", Price = 0, isDefault = false, Sku = 41204127063},
                        new() { Name = "541 - denim blue", Price = 0, isDefault = false, Sku = 41204127058}
                    }},
                new Product
                {
                    Name = "YarnArt Chanelle",
                    Price = 52,
                    Variations = new List<Variation>
                    {
                        new() { Name = "771 - fuxia", Price = 0, isDefault = false, Sku = 36104127001},
                        new() { Name = "02 - white", Price = 0, isDefault = false, Sku = 36104127065},
                    }
                },
                new Product { 
                    Name = "Tea Cup",
                    Price = 15,
                    Variations = new List<Variation>
                    {
                        new() { Name = "red", Price = 0, isDefault = false, Sku = 12104127006},
                        new() { Name = "black", Price = 0, isDefault = false, Sku = 12104127071},
                    }
                }
            };
        }


        private IEnumerable<Location> GenerateLocations()
        {
            return new[]
            {
                new Location { Name = "Gemeni", Address = "Chisinau, str. Stefan cel Mare 126, MD-2005"},
                new Location { Name = "Budapest", Address = "Chisinau, db. Dacia 36, MD-2007"},
                new Location { Name = "Unic", Address = "Chisinau, str. Stefan cel Mare 58, MD-2005"}
            };
        }

        private IEnumerable<LocalVariationQuantity> GenerateLocalVariationQuantities()
        {
            return new[]
            {
                new LocalVariationQuantity {LocationId = 1, VariationId = 1, Quantity = 32 },
                new LocalVariationQuantity {LocationId = 1, VariationId = 2, Quantity = 51 },
                new LocalVariationQuantity {LocationId = 1, VariationId = 3, Quantity = 12 },
                new LocalVariationQuantity {LocationId = 1, VariationId = 4, Quantity = 0 },
                new LocalVariationQuantity {LocationId = 1, VariationId = 5, Quantity = 3 },
                new LocalVariationQuantity {LocationId = 1, VariationId = 6, Quantity = 0 },
                new LocalVariationQuantity {LocationId = 1, VariationId = 7, Quantity = 11 },


                new LocalVariationQuantity {LocationId = 2, VariationId = 1, Quantity = 23 },
                new LocalVariationQuantity {LocationId = 2, VariationId = 2, Quantity = 9 },
                new LocalVariationQuantity {LocationId = 2, VariationId = 3, Quantity = 0 },
                new LocalVariationQuantity {LocationId = 2, VariationId = 4, Quantity = 0 },
                new LocalVariationQuantity {LocationId = 2, VariationId = 5, Quantity = 62 },
                new LocalVariationQuantity {LocationId = 2, VariationId = 6, Quantity = 129 },
                new LocalVariationQuantity {LocationId = 2, VariationId = 7, Quantity = 1 },


                new LocalVariationQuantity {LocationId = 3, VariationId = 1, Quantity = 0 },
                new LocalVariationQuantity {LocationId = 3, VariationId = 2, Quantity = 0 },
                new LocalVariationQuantity {LocationId = 3, VariationId = 3, Quantity = 0 },
                new LocalVariationQuantity {LocationId = 3, VariationId = 4, Quantity = 15 },
                new LocalVariationQuantity {LocationId = 3, VariationId = 5, Quantity = 78 },
                new LocalVariationQuantity {LocationId = 3, VariationId = 6, Quantity = 200 },
                new LocalVariationQuantity {LocationId = 3, VariationId = 7, Quantity = 5 }
            };
        }
    }
}
