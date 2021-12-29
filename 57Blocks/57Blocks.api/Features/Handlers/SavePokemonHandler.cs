using _57Blocks.api.DataBase;
using _57Blocks.api.Features.Commands;
using _57Blocks.api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _57Blocks.api.Features.Handlers
{
    public class SavePokemonHandler : IRequestHandler<SavePokemonCommand, Pokemon>
    {
        private DBContext _context;
        private User _authenticatedUser;
        public SavePokemonHandler(DBContext context, IUserContext userContext)
        {
            _context = context;
            _authenticatedUser = userContext.GetAuthenticatedUser();
        }

        public async Task<Pokemon> Handle(SavePokemonCommand request, CancellationToken cancellationToken)
        {
            if (request.Pokemon == null)
                throw new ValidationException("Pokemon object is mandatory");

            if (string.IsNullOrEmpty(request.Pokemon.Description))
                throw new ValidationException("Pokemon description is mandatory");

            Pokemon pokemon = await _context.Pokemons.Where(x => x.DeleteDate == null && x.PokemonId == request.Pokemon.PokemonId).FirstOrDefaultAsync();

            if (pokemon != null)
            {
                if (pokemon.CreatedBy != _authenticatedUser.UserId)
                    throw new ValidationException("You can only edit your own pokemons");

                pokemon.Description = request.Pokemon.Description;
                pokemon.IsPublic = request.Pokemon.IsPublic;
            }
            else 
            {
                pokemon = request.Pokemon;
                pokemon.PokemonId = Guid.NewGuid();
                pokemon.CreatedBy = _authenticatedUser.UserId;
                await _context.Pokemons.AddAsync(pokemon);
            }

            await _context.SaveChangesAsync();
            return pokemon;
        }
    }
}
