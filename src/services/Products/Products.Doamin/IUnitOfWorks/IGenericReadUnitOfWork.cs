using Products.Doamin.categories;
using Products.Doamin.Contracts;
using Products.Doamin.products;

namespace Products.Doamin
{
    public interface IGenericReadUnitOfWork : IDisposable
    {
        IGenericReadRepository<Product> ProductReadRepository { get; }
        IGenericReadRepository<Category> CategoryReadRepository { get; }
    }
}
