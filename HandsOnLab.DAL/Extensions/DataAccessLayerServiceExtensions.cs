using Microsoft.Extensions.DependencyInjection;
using HandsOnLab.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HandsOnLab.DAL.Extensions;

public static class DataAccessLayerServiceExtensions
{
    public static IServiceCollection AddDataAccessLayerServices(this IServiceCollection services)
    {
        // Register Data Access Layer services
        services.AddScoped<ICar, CarDAL>();
        services.AddScoped<IDealer, DealerDAL>();
        services.AddScoped<IDealerCar, DealerCarDAL>();

        return services;
    }
}
