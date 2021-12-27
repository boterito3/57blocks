using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _57Blocks.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [Route("Register")]
        public ActionResult<string> Register(IFormFile file)
        {
            return "OK";
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<string> Login(string parameter)
        {
            return "OK";
        }
    }
}
