using MediatR;
using Products.Doamin.categories;

namespace Products.Application.Categories.commands
{
    public class AddCategoryCommnad : IRequest<Category> { }
}