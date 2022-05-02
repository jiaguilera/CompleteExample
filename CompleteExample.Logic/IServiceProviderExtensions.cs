using Microsoft.Extensions.DependencyInjection;

namespace CompleteExample.Logic
{
    public static class IServiceProviderExtensions
    {
        public static IServiceCollection AddCqrsHandlers(this IServiceCollection service)
            => service.AddScoped<IEnrollmentQueries, EnrollmentQueries>()
                      .AddScoped<IEnrollmentCommands, EnrollmentCommands>()
                      ;
    }
}
