using _57Blocks.domain.DataBase;
using _57Blocks.domain.Features.Commands;
using _57Blocks.domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _57Blocks.domain.Features.Handlers
{
    public class GetPublicPokemonsHandler : IRequestHandler<GetPublicPokemonsCommand, IEnumerable<Pokemon>>
    {
        private DBContext _context;
        public GetPublicPokemonsHandler(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pokemon>> Handle(GetPublicPokemonsCommand request, CancellationToken cancellationToken)
        {
            var pokemons = await _context.Pokemons.Where(x => x.DeleteDate == null && x.IsPublic).ToListAsync();
            return pokemons;
        }
    }
}
