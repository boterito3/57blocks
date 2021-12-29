using _57Blocks.domain.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _57Blocks.domain.Interfaces
{
    public interface IUserContext
    {
        User GetAuthenticatedUser();
    }
}
