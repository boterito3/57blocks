using _57Blocks.domain.DataBase;
using _57Blocks.domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _57Blocks.domain.Utils
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
