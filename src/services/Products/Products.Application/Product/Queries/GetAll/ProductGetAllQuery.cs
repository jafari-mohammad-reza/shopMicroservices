using MediatR;
using Products.Doamin.products;

namespace Products.Application.Product.Queries.GetAll
{
    public class ProductGetAllQuery : IRequest<List<ProductResponseDto>>
    {
    }
}
