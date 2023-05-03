// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace CAT.Identity
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog"){Scopes={"catalog_fullpermission"}},
            new ApiResource("resource_wishlist"){Scopes={"wishlist_fullpermission"}},
            new ApiResource("resource_gateway"){Scopes={"gateway_fullpermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                        new IdentityResources.Email(),
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile(),
                        new IdentityResource(){Name="roles",DisplayName="Roles",Description="User Roles",UserClaims=new[]{"role"} }
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermission", "Full Permission for Catalog Service"),
                new ApiScope("wishlist_fullpermission", "Full Permission for Wishlist Service"),
                new ApiScope("gateway_fullpermission", "Full Permission for Gateway"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName = ".Net",
                    ClientId = "WebClient",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"catalog_fullpermission", "gateway_fullpermission", IdentityServerConstants.LocalApi.ScopeName}
                },
                new Client
                {
                    ClientName = ".Net",
                    ClientId = "WebClientForUser",
                    AllowOfflineAccess = true,
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = {"wishlist_fullpermission", "gateway_fullpermission", IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile, IdentityServerConstants.StandardScopes.OfflineAccess, IdentityServerConstants.LocalApi.ScopeName, "roles" },
                    
                    // Access Token Lifetime: 1 hour
                    AccessTokenLifetime = 1*60*60,

                    // Refresh Token Lifetime will be expired after 60 days.
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    
                    // Refresh Token Lifetime: 60 days
                    AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,

                    // Refresh Token will be for reuse purposes.
                    RefreshTokenUsage = TokenUsage.ReUse
                }
            };
    }
}