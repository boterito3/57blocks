using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using _57Blocks.domain.Utils;
using System.Security.Claims;
using _57Blocks.domain.DataBase;
using _57Blocks.domain.Features.Commands;

namespace _57Blocks.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [_57BlocksAuthorize]
    public class PokemonsController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        [Route("GetPublicPokemons")]
        public async Task<IActionResult> GetPublicPokemons()
        {
            return Ok(await Mediator.Send(new GetPublicPokemonsCommand()));
        }

        [HttpGet]
        [Route("GetPrivatePokemons")]
        public async Task<IActionResult> GetPrivatePokemons()
        {
            return Ok(await Mediator.Send(new GetPrivatePokemonsCommand()));
        }

        [HttpPost]
        [Route("SavePokemon")]
        public async Task<IActionResult> SavePokemon(SavePokemonCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        [Route("DeletePokemon")]
        public async Task<IActionResult> DeletePokemon(DeletePokemonCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
