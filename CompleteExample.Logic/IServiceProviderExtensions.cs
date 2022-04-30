using Microsoft.Extensions.DependencyInjection;

namespace CompleteExample.Logic
{
    public static class IServiceProviderExtensions
    {
        public static IServiceCollection AddCqrsHandlers(this IServiceCollection service)
        {
            return service.AddScoped<IEnrollmentQueries, EnrollmentQueries>();
        }
    }
}
