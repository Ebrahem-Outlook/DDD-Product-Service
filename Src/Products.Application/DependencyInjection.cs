﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Products.Application.Core.Behaviors;
using System.Reflection;

namespace Products.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));

            cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));

            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        return services;
    }
}
