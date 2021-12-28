using _57Blocks.api.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _57Blocks.api.Interfaces
{
    public interface IUserContext
    {
        User GetAuthenticatedUser();
    }
}
