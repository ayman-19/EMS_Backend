using EMS.Api.Middlewares;
using FastEndpoints;

namespace EMS.Api
{
    public static class Registration
    {
        public static IServiceCollection RegisterMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<ExceptionHandler>();
            services.AddFastEndpoints();
            return services;
        }
    }
}
