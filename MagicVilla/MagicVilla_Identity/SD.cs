﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace MagicVilla_Identity
{
    public static class SD
    {
        public const string Admin = "admin";
        public const string Customer = "customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource> 
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("magic", "Magic Server"),
                new ApiScope(name: "read",   displayName: "Read your data."),
                new ApiScope(name: "write",  displayName: "Write your data."),
                new ApiScope(name: "delete", displayName: "Delete your data.")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "service.client",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "api1", "api2.read_only" }
                },
                new Client
                {
                    ClientId = "magic",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = { "magic", 
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        JwtClaimTypes.Role
                    },
                    RedirectUris = { "https://localhost:44322/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:44322/signout-callback-oidc" },
                }
            };
    }
}
