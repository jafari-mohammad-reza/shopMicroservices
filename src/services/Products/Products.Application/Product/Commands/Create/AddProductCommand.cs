using MediatR;
using Products.Doamin.products;

namespace Products.Application.Product.Commands.Create
{
    public class AddProductCommand : ProductRequestDto , IRequest<ProductResponseDto>
    { }
}