namespace Library.CrossCutting.DependenciesApp
{
    using Library.Domain.Abstractions;
    using Library.Infrastructure.Context;
    using Library.Infrastructure.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration
                                   .GetConnectionString("Sqlite");

            services.AddDbContext<AppDbContext>(options => 
                                                options.UseSqlite(connectionString));

            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
