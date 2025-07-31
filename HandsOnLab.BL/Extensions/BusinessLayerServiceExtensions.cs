using Microsoft.Extensions.DependencyInjection;
using HandsOnLab.BL;
using HandsOnLab.DAL;

namespace HandsOnLab.BL.Extensions;

public static class BusinessLayerServiceExtensions
{
    public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
    {
        // Register Business Logic services
        services.AddScoped<ICar, CarDAL>();
        services.AddScoped<ICarBL, CarBL>();

        return services;
    }
}
