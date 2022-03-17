using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Products.Doamin.Base;
using Products.Doamin.categories;

namespace Products.Doamin.products
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string PermaLink { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Code { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public class ProductConfiguration : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> builder)
            {
                builder.HasKey(b => b.Id);
                builder.Property(b => b.Title).IsRequired().HasMaxLength(200);
                builder.Property(b => b.Description).IsRequired().HasMaxLength(5000);
                builder.Property(b => b.PermaLink).IsRequired().HasMaxLength(200);
                builder.Property(b => b.CoverImageUrl).IsRequired().HasMaxLength(50).HasDefaultValue("https://via.placeholder.com/400x100.png");
                builder.Property(b => b.Code).IsRequired().HasMaxLength(50);
                builder.Property(b => b.CreationDateTime).IsRequired().HasMaxLength(50).HasDefaultValue(DateTime.UtcNow);
                builder.Property(b => b.ModificationDateTime).IsRequired().HasMaxLength(50).HasDefaultValue(DateTime.UtcNow);
                builder.HasData(SeedLargeData());

            }
            internal List<Product> SeedLargeData()
            {
                List<Product> products = new();
                using (StreamReader reader = new(@"SeedData/ProductSeed.json"))
                {
                    string json = reader.ReadToEnd();
                    products = JsonConvert.DeserializeObject<List<Product>>(json);
                }
                return products;
            }
        }
    }
}
