using Microsoft.AspNetCore.Http;
using _57Blocks.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _57Blocks.domain.DataBase;

namespace _57Blocks.domain.Utils
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, DBContext dbContext, I57BlocksSecurityService sostySecurityService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, sostySecurityService, dbContext, token);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, I57BlocksSecurityService sostySecurityService, DBContext dbContext, string token)
        {
            try
            {

                var userId = sostySecurityService.ValidateJwtToken(token);

                var user = dbContext.Users.Where(x => x.UserId == userId).First();

                // attach user to context on successful jwt validation
                context.Items["User"] = user;
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
