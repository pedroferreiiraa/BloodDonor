using BloodDonor.Application.Commands.CreateDonorCommand;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonor.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddHandlers();
        
        return services;
    }

    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<CreateDonorCommand>()
        );

        return services;
    }
}