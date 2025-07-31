using Microsoft.Extensions.DependencyInjection;
using HandsOnLab.BL;
using HandsOnLab.DAL;
using HandsOnLab.DAL.Extensions;
using HandsOnLab.BL.Profiles;

namespace HandsOnLab.BL.Extensions;

public static class BusinessLayerServiceExtensions
{
    public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
    {
        services.AddDataAccessLayerServices();

        //add automapper
        services.AddAutoMapper(cfg => cfg.LicenseKey = "",
        typeof(BusinessLayerServiceExtensions));

        // Register Business Logic services
        services.AddScoped<ICarBL, CarBL>();
        services.AddScoped<IDealerBL, DealerBL>();

        return services;
    }
}
