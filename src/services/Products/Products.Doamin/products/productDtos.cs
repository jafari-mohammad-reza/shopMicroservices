using System.ComponentModel;
using Products.Doamin.Base;

namespace Products.Doamin.products
{
    public class ProductRequestDto : productDTO
    {
        public int CategoryId { get; set; }
    }
    public class ProductResponseDto : productDTO
    {
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
    }

    public class productDTO : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string PermaLink { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Code { get; set; }
    }

}