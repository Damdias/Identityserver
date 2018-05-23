using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAppIdentityServer
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()

            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId ="AuthWeb",
                    ClientName="AuthWeb Demo Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris=new List<string>{"https://localhost:44309/signin-oidc"},
                    PostLogoutRedirectUris = new List<string>{"https://localhost:44309/signout-callback-oidc"},
                    AllowedScopes = new List<string>
                    {
                       IdentityServerConstants.StandardScopes.OpenId,
                       IdentityServerConstants.StandardScopes.Profile
                    }
                },
                new Client
                {
                    ClientId="AuthWeb_Javascript",
                    AllowedGrantTypes= GrantTypes.Implicit,
                    RedirectUris = {"https://localhost:44309/SilentSignInCallback.html"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        "WebApi"
                    },
                   AllowedCorsOrigins= { "https://localhost:44309" },
                   AllowAccessTokensViaBrowser = true,
                   RequireConsent = false

                }
            };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("webApi")
            };
        }
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "Damith",
                    Password="test",
                    Claims = new[]
                    {
                        new Claim("name","Zerokoll")
                    }
                }
            };
        }
    }
   
}
