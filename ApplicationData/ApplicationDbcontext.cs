using Microsoft.EntityFrameworkCore;
using Models;

namespace ApplicationData
{
    public class ApplicationDbcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source = (localdb)\MSSQLLocalDB;Initial Catalog=CarStore; Integrated Security=true;");
        }



        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<CarPart> CarsParts{ get; set; }
    }
}