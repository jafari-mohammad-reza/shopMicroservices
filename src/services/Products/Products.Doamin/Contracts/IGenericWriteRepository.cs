using Products.Doamin.Base;
using Products.Doamin.products;

namespace Products.Domain.Contracts
{
    public interface IGenericWriteRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<bool> RemoveAsync(T entity);
    }
}