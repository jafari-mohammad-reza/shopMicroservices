using Microsoft.EntityFrameworkCore;
using Products.Doamin.Base;
using Products.Doamin.products;
using Products.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.InfraStructure.Contracts
{
    public class GenericWriteRepository<T> : IGenericWriteRepository<T> where T : BaseEntity
    {
        private readonly ProductsDbContext _context;
        private  DbSet<T> _db { get; set; }
        public GenericWriteRepository(ProductsDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
             await _db.AddAsync(entity);
            await SaveChanges();
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            _db.Remove(entity);
            await SaveChanges();
            return true;
        }

        public async Task UpdateAsync(T entity)
        {
             _db.Update(entity);
            await SaveChanges();
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
