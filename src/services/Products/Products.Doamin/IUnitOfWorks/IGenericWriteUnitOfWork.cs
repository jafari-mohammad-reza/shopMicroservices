using Products.Doamin.categories;
using Products.Doamin.products;
using Products.Domain.Contracts;

namespace Products.Doamin
{
    public interface IGenericWriteUnitOfWork : IDisposable
    {
        IGenericWriteRepository<Product> ProductWriteRepository { get; }
        IGenericWriteRepository<Category> CategoryWriteRepository { get; }
    }
}