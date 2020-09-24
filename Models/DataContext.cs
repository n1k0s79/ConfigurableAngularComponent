using Microsoft.EntityFrameworkCore;

namespace QualcoApp.Models
{
    public class DataContext : DbContext
    {
        public DataContext() { } // required for unit tests
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}