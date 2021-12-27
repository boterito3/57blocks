using _57Blocks.api.DataBase;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _57Blocks.api.Features.Commands
{
    public class GetPublicPokemonsCommand : IRequest<IEnumerable<Pokemon>>
    {
    }
}
