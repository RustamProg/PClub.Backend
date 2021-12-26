using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace PClub.Backend.Auth.Config
{
    internal static class IdentityConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResource("roles", "User role(s)", new List<string> { "role" })
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("pclub.api", "PClub API Scope")
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("pclub.api", "PClub Web API ")
                {
                    Scopes = { "pclub.api" },
                    Description = "Сервер аутентификации",
                    ApiSecrets = new List<Secret> { new Secret("PClubSecret".Sha256()) },
                    UserClaims = new List<string> { "role" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName = "PClubClient",
                    ClientId = "PClubClientId",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        "roles",
                        "pclub.api"
                    },
                    ClientSecrets = { new Secret("PClubClientSecret".Sha512()) },
                    PostLogoutRedirectUris = new List<string> { "https://localhost:3000/signout-callback-oidc" },
                    AccessTokenLifetime = 60 * 60 * 24 * 7,
                    AllowOfflineAccess = false,
                }
            };
    }
}
