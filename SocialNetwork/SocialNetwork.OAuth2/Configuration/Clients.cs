﻿using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace SocialNetwork.OAuth.Configuration
{
    public class Clients
    {
        public static IEnumerable<Client> All()
        {
            return new[] {
                new Client
                {
                    ClientId = "fekberg",
                    ClientSecrets = new [] { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new [] { "socialnetwork" }
                },
                new Client
                {
                    ClientId = "socialnetwork_implicit",
                    ClientSecrets = new [] { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new [] {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "socialnetwork"},
                    RedirectUris=new string[]{ "http://localhost:28851/signin-oidc" },
                    PostLogoutRedirectUris=new string[]{"http://localhost:28851/signout-callback-oidc" }

                }
            };
        }
    }
    public class Users
    {
        public static List<TestUser> All()
        {
            return new List<TestUser> {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "surenvanyan@gmail.com",
                    Password = "password"
                }
            };
        }
    }

    public class ApiResources
    {
        public static IEnumerable<ApiResource> All()
        {
            return new[] {
                new ApiResource("socialnetwork", "Social Network")
            };
        }
      
    }

    public class InMemoryConfiguration
    {
        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new IdentityResource[]
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile()
                };

        }
    }
}
