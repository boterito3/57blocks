﻿using _57Blocks.api.DataBase;
using _57Blocks.api.Features.Commands;
using _57Blocks.api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _57Blocks.api.Features.Handlers
{
    public class GetPublicPokemonsHandler : IRequestHandler<GetPublicPokemonsCommand, IEnumerable<Pokemon>>
    {
        private DBContext _context;
        private User _authentiCatedUser;
        public GetPublicPokemonsHandler(DBContext context, IUserContext userContext)
        {
            _context = context;
            _authentiCatedUser = userContext.GetAuthenticatedUser();
            
        }
        public async Task<IEnumerable<Pokemon>> Handle(GetPublicPokemonsCommand request, CancellationToken cancellationToken)
        {
            var pokemons = await _context.Pokemons.Where(x => x.IsPublic).ToListAsync();
            return pokemons;
        }
    }
}
