using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _57Blocks.api.Features.Commands
{
    public class DeletePokemonCommand : IRequest<bool>
    {
        public Guid PokemonId { get; set; }
    }
}
