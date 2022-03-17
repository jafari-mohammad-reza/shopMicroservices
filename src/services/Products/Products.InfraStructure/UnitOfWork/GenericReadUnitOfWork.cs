using Products.Doamin;
using Products.Doamin.categories;
using Products.Doamin.Contracts;
using Products.Doamin.products;
using Products.InfraStructure.Contracts;

namespace Products.InfraStructure.UnitOfWork
{
    public class GenericReadUnitOfWork : IGenericReadUnitOfWork
    {
        private readonly ProductsDbContext _context;
        public GenericReadUnitOfWork(ProductsDbContext context)
        {
            _context = context;
        }
        private IGenericReadRepository<Product> productReadRepository;
        public IGenericReadRepository<Product> ProductReadRepository => productReadRepository ??= new GenericReadRepository<Product>(_context);
        private IGenericReadRepository<Category> categoryReadRepository;
        public IGenericReadRepository<Category> CategoryReadRepository => categoryReadRepository ??= new GenericReadRepository<Category>(_context);

        public void Dispose()
        {
           _context.Dispose();
        }
    }
}
