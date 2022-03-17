using System.Reflection;
using Products.Application.Product.Commands.Create;
using Products.Doamin.products;
using Products.InfraStructure;

namespace Products.API
{
    public static class Assemblies
    {
        public static readonly Assembly InfrastructureAssembly = typeof(ProductsDbContext).Assembly;
        public static readonly Assembly EntityAssembly = typeof(Product).Assembly;
        public static readonly Assembly ApplicationAssembly = typeof(AddProductCommand).Assembly;
    }
}