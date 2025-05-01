﻿using System.Reflection;
using EMS.Application.Behaviores;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.Application
{
    public static class Registeration
    {
        public static IServiceCollection RegisterApplicationDepenedncies(
            this IServiceCollection services
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
