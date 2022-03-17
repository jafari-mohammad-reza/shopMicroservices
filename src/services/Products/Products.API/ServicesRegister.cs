using System.Text.Json.Serialization;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Behaviors;
using Products.Application.Behaviours;
using Products.Doamin;
using Products.Doamin.Contracts;
using Products.Domain.Contracts;
using Products.InfraStructure;
using Products.InfraStructure.Contracts;
using Products.InfraStructure.UnitOfWork;

namespace Products.API
{
    public static class Servicesregister
    {
        public static IServiceCollection AddGeneralServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            return builder.Services;
        }
        public static IServiceCollection AddInfrastructureservices(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(Assemblies.InfrastructureAssembly);
            builder.Services.AddDbContext<ProductsDbContext>(options =>
                    {
                        options.UseNpgsql(builder.Configuration.GetConnectionString("ProductsDbConnection"));
                    });
            builder.Services.AddScoped<IGenericReadUnitOfWork, GenericReadUnitOfWork>();
            builder.Services.AddScoped<IGenericWriteUnitOfWork, GenericWriteUnitOfWork>();
            builder.Services.AddScoped(typeof(IGenericReadRepository<>) , typeof(GenericReadRepository<>));
            builder.Services.AddScoped(typeof(IGenericWriteRepository<>), typeof(GenericWriteRepository<>));
            return builder.Services;
        }

        public static IServiceCollection AddApplicationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddValidatorsFromAssembly(Assemblies.ApplicationAssembly);
            builder.Services.AddMediatR(Assemblies.ApplicationAssembly);
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return builder.Services;
        }
    }
}