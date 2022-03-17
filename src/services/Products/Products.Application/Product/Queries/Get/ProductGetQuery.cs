using MediatR;
using Products.Doamin.products;

namespace Products.Application.Product.Queries.Get
{
    public class ProductGetQuery  : IRequest<ProductResponseDto>
    {
        public int Id { get; set; }
    }
}
