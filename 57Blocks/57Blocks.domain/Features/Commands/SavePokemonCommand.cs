using _57Blocks.domain.DataBase;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _57Blocks.domain.Features.Commands
{
    public class SavePokemonCommand : IRequest<Pokemon>
    {
        public Pokemon Pokemon { get; set; }
    }
}
