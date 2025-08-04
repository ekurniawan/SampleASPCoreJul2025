using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HandsOnLab.DAL.Extensions;

public static class DataAccessLayerServiceExtensions
{
    public static IServiceCollection AddDataAccessLayerServices(this IServiceCollection services)
    {
        // Add Entity Framework
        services.AddDbContext<AutomotiveDB3Context>(options =>
            options.UseSqlServer(services.BuildServiceProvider()
                .GetRequiredService<IConfiguration>()
                .GetConnectionString("AutomotiveDBConnectionString")));

        // Add Identity with role
        //also add role
        services.AddIdentityCore<IdentityUser>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
        }).AddRoles<IdentityRole>().AddEntityFrameworkStores<AutomotiveDB3Context>();


        // Register Data Access Layer services
        services.AddScoped<ICar, CarDAL>();
        services.AddScoped<IDealer, DealerDAL>();
        services.AddScoped<IDealerCar, DealerCarDAL>();
        services.AddScoped<IUsman, UsmanDAL>();

        return services;
    }
}
