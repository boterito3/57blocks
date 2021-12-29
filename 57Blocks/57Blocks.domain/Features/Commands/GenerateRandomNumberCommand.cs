using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _57Blocks.domain.Features.Commands
{
    public class GenerateRandomNumberCommand : IRequest<int>
    {
    }
}
