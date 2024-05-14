using Microsoft.Extensions.DependencyInjection;

using Jugendretter_API.Contracts;
using Jugendretter_API.Repository;
using Jugendretter_API.LoggerService;

namespace Jugendretter_API.Extensions
{
    public static class ServiceExtension
    {

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddScoped<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, ReporitoryWrapper>();
        }
    }
}
