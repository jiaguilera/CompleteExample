using Microsoft.Extensions.DependencyInjection;

namespace CompleteExample.Logic.Extensions
{
    public static class IServiceProviderExtensions
    {
        public static IServiceCollection AddCqrsHandlers(this IServiceCollection service)
            => service.AddScoped<IEnrollmentQueries, EnrollmentQueries>()
                      .AddScoped<IEnrollmentCommands, EnrollmentCommands>()
                      ;
    }
}
