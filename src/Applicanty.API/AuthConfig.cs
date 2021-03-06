﻿using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Applicanty.API
{
    public class AuthConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("applicantyAPI")
                {
                    ApiSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    UserClaims =
                    {
                        JwtClaimTypes.Email,
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Id
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    AccessTokenLifetime = 3600,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "applicantyAPI" }
                }
            };
        }
    }
}