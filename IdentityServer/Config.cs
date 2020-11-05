using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        private static Client authorizationCodeFlowClient;

        public static IEnumerable<ApiScope> ApiScopes =>
            new[]
            {
                new ApiScope("api1.read_only"),
                new ApiScope("api1.full_access")
            };

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "api1",
                    DisplayName = "Protected Produce API",
                    Scopes =
                    {
                        "api1.full_access",
                        "api1.read_only"
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            authorizationCodeFlowClient = new Client
            {
                ClientId = "bsra",
                ClientName = "Blog Spa React App",
                RequirePkce = true,
                RequireClientSecret = false,
                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { configuration["RedirectUris"] },
                PostLogoutRedirectUris = { configuration["PostLogoutRedirectUris"] },
                AllowedCorsOrigins = { configuration["AllowedCorsOrigins"] },

                AllowedScopes =
                {
                    "openid",
                    "profile","name","username","givenname",
                    "api1.read_only",
                    "api1.full_access"
                }
            };

            return new[] { authorizationCodeFlowClient };
        }
    }
}
