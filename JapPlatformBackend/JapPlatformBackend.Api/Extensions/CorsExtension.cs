﻿namespace JapPlatformBackend.Api.Extensions
{
    public static class CorsExtension
    {
        public static void SetupCors(this IServiceCollection service)
        {
            var provider = service.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IConfiguration>();
            var fronendURL = configuration.GetValue<string>("Frontend_URL");

            service.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                    builder =>
                    {
                        builder.WithOrigins(fronendURL)
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
        }

    }
}
