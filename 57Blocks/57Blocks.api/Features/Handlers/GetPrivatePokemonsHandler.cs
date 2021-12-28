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
    public class GetPrivatePokemonsHandler : IRequestHandler<GetPrivatePokemonsCommand, IEnumerable<Pokemon>>
    {
        private DBContext _context;
        private User _authenticatedUser;
        public GetPrivatePokemonsHandler(DBContext context, IUserContext userContext)
        {
            _context = context;
            _authenticatedUser = userContext.GetAuthenticatedUser();
            
        }

        public async Task<IEnumerable<Pokemon>> Handle(GetPrivatePokemonsCommand request, CancellationToken cancellationToken)
        {
            var pokemons = await _context.Pokemons.Where(x => !x.IsPublic && x.CreatedBy == _authenticatedUser.UserId).ToListAsync();
            return pokemons;
        }
    }
}