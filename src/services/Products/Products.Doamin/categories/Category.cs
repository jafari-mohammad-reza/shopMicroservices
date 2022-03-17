using System.IO;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Products.Doamin.Base;
using Products.Doamin.products;

namespace Products.Doamin.categories
{
    public class Category : BaseEntity
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public int? ParentCategoryId { get; set; }
        public string PermaLink { get; set; }
        public bool IsActive { get; set; }
        public int Priority { get; set; }
        public string BannerUrl { get; set; }
        public string IconUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public ICollection<Product> Products { get; set; }
        public Category ParentCategory { get; set; }

        public class CategoryConfiguration : IEntityTypeConfiguration<Category>
        {
            void IEntityTypeConfiguration<Category>.Configure(EntityTypeBuilder<Category> builder)
            {
                builder.HasKey(b => b.Id);
                builder.Property(b => b.Title).IsRequired().HasMaxLength(200);
                builder.Property(b => b.Description).IsRequired().HasMaxLength(5000);
                builder.Property(b => b.PermaLink).IsRequired().HasMaxLength(200);
                builder.Property(b => b.BannerUrl).IsRequired().HasMaxLength(50).HasDefaultValue("https://via.placeholder.com/400x100.png");
                builder.Property(b => b.IconUrl).IsRequired().HasMaxLength(50).HasDefaultValue("https://via.placeholder.com/85.png");
                builder.Property(b => b.ThumbnailUrl).IsRequired().HasMaxLength(200).HasDefaultValue("https://via.placeholder.com/600.png");
                builder.Property(b => b.CreationDateTime).IsRequired().HasDefaultValue(DateTime.UtcNow);
                builder.Property(b => b.ModificationDateTime).IsRequired().HasDefaultValue(DateTime.UtcNow);
                builder.HasData(SeedLargeData());
            }
            internal List<Category> SeedLargeData()
            {
                List<Category> categories = new();
                using (StreamReader reader = new(@"SeedData/CategorySeed.json"))
                {
                    string json = reader.ReadToEnd();
                    categories = JsonConvert.DeserializeObject<List<Category>>(json);   
                }
                return categories;
            }
        }

    }
}
