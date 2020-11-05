using IdentityModel;
using IdentityServer4;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;

namespace IdentityServer.DummyData
{
    public class AppUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "Henly Wood Road",
                    locality = "Reading",
                    postal_code = "RG6 7EE",
                    country = "UK"
                };

                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "publisher",
                        Username = "publisher",
                        Password = "publisher",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Satish Chatap"),
                            new Claim(JwtClaimTypes.GivenName, "Satish"),
                            new Claim(JwtClaimTypes.FamilyName, "Chatap"),
                            new Claim(JwtClaimTypes.Email, "publisher@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://publisher.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                            ,new Claim(JwtClaimTypes.Scope,"api1.full_access")
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "employee",
                        Username = "employee",
                        Password = "employee",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Employee Chatap"),
                            new Claim(JwtClaimTypes.GivenName, "Employee"),
                            new Claim(JwtClaimTypes.FamilyName, "Chatap"),
                            new Claim(JwtClaimTypes.Email, "employee@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://employee.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                            ,new Claim(JwtClaimTypes.Scope,"api1.read_only")
                        }
                    }
                };
            }
        }
    }
}
