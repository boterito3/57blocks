using _57Blocks.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _57Blocks.domain.Utils
{
    public class ValidationService : IValidationService
    {
        public bool EmailIsValid(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public bool PasswordIsValid(string password)
        {
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum10Chars = new Regex(@".{10,}");

            return hasLowerChar.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum10Chars.IsMatch(password) && (password.Contains('!') || password.Contains('@') || password.Contains('#') || password.Contains('?') || password.Contains(']'));
        }
    }
}
