using Products.Doamin;
using Products.Doamin.categories;
using Products.Doamin.products;
using Products.Domain.Contracts;
using Products.InfraStructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.InfraStructure.UnitOfWork
{
    public  class GenericWriteUnitOfWork : IGenericWriteUnitOfWork
    {
        private readonly ProductsDbContext _context;
        public GenericWriteUnitOfWork(ProductsDbContext context)
        {
            _context = context;
        }
        private IGenericWriteRepository<Product> productWriteRepository;
        public IGenericWriteRepository<Product> ProductWriteRepository => productWriteRepository ??= new GenericWriteRepository<Product>(_context);
        private IGenericWriteRepository<Category> categoryWriteRepository;
        public IGenericWriteRepository<Category> CategoryWriteRepository => categoryWriteRepository ??= new GenericWriteRepository<Category>(_context);

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
