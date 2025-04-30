﻿using EMS.Application.Behaviores;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace EMS.Application
{
    public static class Registeration
    {
        public static IServiceCollection RegisterApplicationDepenedncies(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            services.AddValidatorsFromAssembly(typeof(Registeration).Assembly);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
