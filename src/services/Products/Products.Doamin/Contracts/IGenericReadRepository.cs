using Products.Doamin.Base;
using Products.Doamin.products;

namespace Products.Doamin.Contracts
{
    public interface IGenericReadRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<T> GetAsyncNotTracked(int id);
    }
}