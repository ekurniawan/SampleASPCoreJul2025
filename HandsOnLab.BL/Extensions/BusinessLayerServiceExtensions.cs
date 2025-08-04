using HandsOnLab.BL;
using HandsOnLab.BL.Helpers;
using HandsOnLab.BL.Profiles;
using HandsOnLab.DAL;
using HandsOnLab.DAL.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace HandsOnLab.BL.Extensions;

public static class BusinessLayerServiceExtensions
{
    public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
    {
        services.AddDataAccessLayerServices();

        //add jwt token
        var appSettingsSection = services.BuildServiceProvider()
            .GetRequiredService<IConfiguration>()
            .GetSection("AppSettings");
        services.Configure<AppSettings>(appSettingsSection);
        var appSettings = appSettingsSection.Get<AppSettings>();
        if (string.IsNullOrEmpty(appSettings?.Secret))
        {
            throw new ArgumentNullException(nameof(appSettings.Secret), "AppSettings Secret cannot be null or empty");
        }
        var key = Encoding.ASCII.GetBytes(appSettings.Secret);
        if (key.Length == 0)
        {
            throw new ArgumentException("AppSettings Secret must be a valid non-empty string", nameof(appSettings.Secret));
        }
        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


        //add automapper
        services.AddAutoMapper(cfg => cfg.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzg1NDU2MDAwIiwiaWF0IjoiMTc1Mzk1MjI4OSIsImFjY291bnRfaWQiOiIwMTk4NWZiMTRkZTM3NTI5OWY5NTdjOTNkNmZiNmFlZiIsImN1c3RvbWVyX2lkIjoiY3RtXzAxazFmdjgwbmdtemFkOHlzdGhqYmUxdDJxIiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.YIr9CnbuLLo52fz7gjKCGDZnLGsMeH2N2nEzzRBIfoiOGHLMkQiLmH1WJ0806Ou8H6rouXAjKiKkiMcNfbsVj4H5exzCPLxSons3veAosP3b3338MJ8LD73A2pVfjmJTNDQFFuu7ntq9Mc6vkgiwiXyWpF9VfyD9lXnwTeOma8EUohtQ6g_p0k5fN20pYoi57TimVvCTZBatNv7cy6J5M6LrzvprZ0TvvRSwUEou8dW1smPN90s4qx3ld6k4BmOwehrj-OYY9dMcK7GeqK54blrWK0hWQ-PzJINV5c29A0TvDYg47SyGOrDsTwEcP94yceWvCwLqiGgHMGvTmkQ_Fw",
        typeof(BusinessLayerServiceExtensions));

        // Register Business Logic services
        services.AddScoped<ICarBL, CarBL>();
        services.AddScoped<IDealerBL, DealerBL>();
        services.AddScoped<IDealerCarBL, DealerCarBL>();
        services.AddScoped<IUsmanBL, UsmanBL>();

        return services;
    }
}
