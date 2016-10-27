using Dapper;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using static IdentityModel.OidcConstants;

namespace WebApplication3.Configuration
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            //Validate user
            //Use dapper to get user from database

            using (IDbConnection connection = new SqlConnection("String de conexão"))
            {
                string sql = @"select * 
                                 from Accounts 
                                where UserName = @UserName 
                                  and Password = @Password";

                var user = connection.Query<User>(sql, new
                {
                    UserName = context.UserName,
                    Password = context.Password
                }).SingleOrDefault();

                if (user == null)
                {
                    context.Result = new GrantValidationResult(TokenErrors.InvalidRequest, "User name or password is incorrect.");
                    return Task.FromResult(0);
                }

                context.Result = new GrantValidationResult(user.Id.ToString(), "password");
                return Task.FromResult(0);
            }
        }
    }
}
