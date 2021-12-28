﻿using _57Blocks.api.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using _57Blocks.api.Utils;

namespace _57Blocks.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        [Route("GetPublicPokemons")]
        [_57BlocksAuthorize]
        public async Task<IActionResult> GetPublicPokemons()
        {
            return Ok(await Mediator.Send(new GetPublicPokemonsCommand()));
        }
    }
}