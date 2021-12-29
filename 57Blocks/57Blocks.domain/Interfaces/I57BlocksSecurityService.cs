using System;
using System.Collections.Generic;
using System.Text;

namespace _57Blocks.domain.Interfaces
{
    public interface I57BlocksSecurityService
    {
        string GenerateJwtToken(string userId, string userEmail);
        Guid ValidateJwtToken(string token);
        string Hash(string text);
    }
}
