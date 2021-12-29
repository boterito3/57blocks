using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _57Blocks.domain.Interfaces
{
    public interface IValidationService
    {
        bool EmailIsValid(string email);
        bool PasswordIsValid(string password);
    }
}
