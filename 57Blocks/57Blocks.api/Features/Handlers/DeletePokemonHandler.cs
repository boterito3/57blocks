using _57Blocks.api.DataBase;
using _57Blocks.api.Features.Commands;
using _57Blocks.api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _57Blocks.api.Features.Handlers
{
    public class DeletePokemonHandler : IRequestHandler<DeletePokemonCommand, bool>
    {
        private DBContext _context;
        private User _authenticatedUser;
        public DeletePokemonHandler(DBContext context, IUserContext userContext)
        {
            _context = context;
            _authenticatedUser = userContext.GetAuthenticatedUser();
        }
        public async Task<bool> Handle(DeletePokemonCommand request, CancellationToken cancellationToken)
        {
            if (request.PokemonId == Guid.Empty)
                throw new ValidationException("Pokemon id is invalid");

            Pokemon pokemon = await _context.Pokemons.Where(x => x.DeleteDate == null && x.PokemonId == request.PokemonId).FirstOrDefaultAsync();

            if (pokemon == null)
                throw new ValidationException("Pokemon not found");

            if (pokemon.CreatedBy != _authenticatedUser.UserId)
                throw new ValidationException("You can only delete your own pokemons");

            pokemon.DeleteDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
