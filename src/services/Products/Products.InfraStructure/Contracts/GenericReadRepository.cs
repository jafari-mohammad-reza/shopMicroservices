using Microsoft.EntityFrameworkCore;
using Products.Doamin.Base;
using Products.Doamin.Contracts;

namespace Products.InfraStructure.Contracts
{
    public class GenericReadRepository<T> : IGenericReadRepository<T> where T : BaseEntity
    {
        private readonly ProductsDbContext _context;
        public DbSet<T> DB { get; set; }
        public GenericReadRepository(ProductsDbContext context)
        {
            _context = context;
            DB = _context.Set<T>();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await DB.ToListAsync();  
        }

        public async Task<T> GetAsync(int id)
        {
            return await DB.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<T> GetAsyncNotTracked(int id)
        {
            return await DB.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
