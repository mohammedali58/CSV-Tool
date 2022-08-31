using System;
using CSV.application;
using Microsoft.Extensions.DependencyInjection;


namespace CSV.application
{
    public static class startup
    {
        public static IServiceCollection ConfigureLogResolver(this IServiceCollection services)
        {
            services.AddScoped<ILogResolver, LogResolver>();

            return services;
        }


    }
}

