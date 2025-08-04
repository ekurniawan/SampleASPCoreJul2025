using HandsOnLab.BL;
using HandsOnLab.BL.Profiles;
using HandsOnLab.DAL;
using HandsOnLab.DAL.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace HandsOnLab.BL.Extensions;

public static class BusinessLayerServiceExtensions
{
    public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
    {
        services.AddDataAccessLayerServices();

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
