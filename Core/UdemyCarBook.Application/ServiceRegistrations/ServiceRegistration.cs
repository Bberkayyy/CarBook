using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace UdemyCarBook.Application.ServiceRegistrations;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
        return services;
    }
}
