using _57Blocks.api.DataBase;
using _57Blocks.api.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _57Blocks.api.Utils
{
    public class UserContext : IUserContext
    {
        public User User { get; }
        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            User = (User)httpContextAccessor.HttpContext.Items["User"];
        }

        public User GetAuthenticatedUser()
        {
            return User;
        }

    }
}
