using _57Blocks.api.DataBase;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _57Blocks.api.Features.Commands
{
    public class GetPrivatePokemonsCommand : IRequest<IEnumerable<Pokemon>>
    {
    }
}
