using IRM.Livraria.Infraestructure.Context;
using IRM.Livraria.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IRM.Livraria.CrossCutting.DependenciesApp;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqLiteConnection");

        services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlite(connectionString));

        services.AddScoped<LivroRepository, LivroRepository>();

        return services;
    }
}
