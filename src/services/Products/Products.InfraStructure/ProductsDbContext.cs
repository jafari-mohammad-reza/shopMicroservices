using Microsoft.EntityFrameworkCore;
using Products.Doamin.categories;
using Products.Doamin.products;

namespace Products.InfraStructure
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options ) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

}
