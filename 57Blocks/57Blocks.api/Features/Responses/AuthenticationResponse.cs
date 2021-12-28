using _57Blocks.api.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace _57Blocks.api.Features.Responses
{
    public class AuthenticationResponse
    {
        public User User { get; set; }
        public string AccessToken { get; set; }
    }
}
