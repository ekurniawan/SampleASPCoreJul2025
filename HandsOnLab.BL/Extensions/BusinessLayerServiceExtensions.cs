using Microsoft.Extensions.DependencyInjection;
using HandsOnLab.BL;
using HandsOnLab.DAL;
using HandsOnLab.DAL.Extensions;

namespace HandsOnLab.BL.Extensions;

public static class BusinessLayerServiceExtensions
{
    public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
    {
        services.AddDataAccessLayerServices();
        // Register Business Logic services
        services.AddScoped<ICarBL, CarBL>();

        return services;
    }
}
