using System;
using Microsoft.Extensions.DependencyInjection;


namespace CSV.persistence
{
    public static class startup
    {
        public static IServiceCollection ConfigurePersistence(this IServiceCollection services)
        {
            services.AddScoped<IFileManager,FileManager>();

            return services;
        }


    }
}

