using EMS.Domain.Abstraction;
using EMS.Persistence.Context;
using EMS.Persistence.Impelementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.Persistence
{
    public static class Registeration
    {
        public static IServiceCollection RegisterPersistenceDependancies(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            string connectionString = configuration.GetConnectionString("EMS_CONNECTIONSTRING");

            services.AddDbContextPool<EMSDBContext>(cfg =>
            {
                cfg.UseSqlServer(connectionString);
            });
            services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}
