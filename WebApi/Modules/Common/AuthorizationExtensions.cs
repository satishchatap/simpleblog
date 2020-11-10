namespace WebApi.Modules.Common
{
    using Application.Services;
    using FeatureFlags;
    using Infrastructure.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.FeatureManagement;
    using WebApi.Modules.Authorization;

    /// <summary>
    ///     Authorization Extensions.
    /// </summary>
    public static class AuthorizationExtensions
    {
        /// <summary>
        ///     Add Authorization Extensions.
        /// </summary>
        public static IServiceCollection AddAuthorization(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new System.ArgumentNullException(nameof(configuration));
            }

            IFeatureManager featureManager = services
                .BuildServiceProvider()
                .GetRequiredService<IFeatureManager>();

            bool isEnabled = featureManager
                .IsEnabledAsync(nameof(CustomFeature.Authorization))
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            if (isEnabled)
            {
                services.AddScoped<IUserService, UserService>();
            }
            else
            {
                services.AddScoped<IUserService, TestUserService>();
            }
            services
                .AddAuthorization(options =>
                {
                    options.AddPolicy("ReadOnly", policy => policy.Requirements.Add(new AccessRightRequirement("read_only")));
                    options.AddPolicy("FullAccess", policy => policy.Requirements.Add(new AccessRightRequirement("full_access")));
                    options.AddPolicy("AnyAccess", policy => policy.Requirements.Add(new AccessRightRequirement("full_access,read_only")));
                });
            services.AddTransient<IAuthorizationHandler, AccessAuthorizationHandler>();            

            return services;
        }
    }
}
