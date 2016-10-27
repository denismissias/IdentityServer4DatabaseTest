using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Configuration
{
    public class Scopes
    {
        public static List<Scope> GetScopes()
        {
            return new List<Scope>()
            {
                new Scope()
                {
                    Name = "myApi1",
                    Description = "Some description about"
                }
            };
        }
    }
}
