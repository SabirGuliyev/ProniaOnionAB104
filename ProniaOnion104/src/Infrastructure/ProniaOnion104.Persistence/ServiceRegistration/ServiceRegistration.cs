using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion104.Application.Abstractions.Repositories;
using ProniaOnion104.Application.Abstractions.Services;
using ProniaOnion104.Persistence.Contexts;
using ProniaOnion104.Persistence.Implementations.Repositories;
using ProniaOnion104.Persistence.Implementations.Services;


namespace ProniaOnion104.Persistence.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<ICategoryRepository, CategoryRepository>();


            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }
    }
}
