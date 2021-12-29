using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using _57Blocks.domain.Utils;
using _57Blocks.domain.Features.Commands;

namespace _57Blocks.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegistrationCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet]
        [Route("GenerateRandomNumber")]
        public async Task<IActionResult> GenerateRandomNumber()
        {
            return Ok(await Mediator.Send(new GenerateRandomNumberCommand()));
        }
    }
}
