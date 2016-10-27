using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Configuration
{
    public class Clients
    {
        public static List<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "resClient",
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("topsecret".Sha256())
                    },
                    AllowedScopes = new List<string>()
                    {
                        "myApi1"
                    },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword
                }
            };
        }
    }
}
