using MediatR;
using Products.Doamin.products;

namespace Products.Application.Product.Commands.Update
{
    public class UpdateProductCommand : ProductRequestDto, IRequest<bool> { }
}