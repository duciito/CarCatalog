using CC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Contexts
{
    public class CarCatalogDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarType> CarTypes { get; set; }

        public CarCatalogDbContext() : base(@"Server=localhost;Database=CarCatalog;Trusted_Connection=True;")
        { }
    }
}
