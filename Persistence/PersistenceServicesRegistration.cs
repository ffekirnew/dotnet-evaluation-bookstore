namespace Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Persistence.Repositories;
using Application.Contracts.Persistence.Repositories;


public static class PersistenceServicesRegistration
{
  public static IServiceCollection ConfigurePersistenceServices(
      this IServiceCollection services,
      IConfiguration configuration
  )
  {
    services.AddDbContext<AppDbContext>(options =>
      {
        options.UseNpgsql(configuration.GetConnectionString("DefaultConn"));
      }
    );


    services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    services.AddScoped<IUnitOfWork, UnitOfWork>();
    return services;
  }
}
