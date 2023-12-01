using B2GTechTask.Core.Implementations;
using B2GTechTask.Core.Interfaces;
using B2GTechTask.Infrastructure.Implementations;
using B2GTechTask.Infrastructure.Interfaces;

namespace B2GTechTask.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            return services;
        }
        public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}
