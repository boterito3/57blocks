using _57Blocks.api.DataBase;
using _57Blocks.api.Features.Commands;
using _57Blocks.api.Features.Responses;
using _57Blocks.api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _57Blocks.api.Features.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, AuthenticationResponse>
    {
        private DBContext _context;
        private I57BlocksSecurityService _securityService;
        private IValidationService _validationService;

        public LoginHandler(DBContext context, I57BlocksSecurityService securityService, IValidationService validationService)
        {
            _context = context;
            _securityService = securityService;
            _validationService = validationService;
        }

        public async Task<AuthenticationResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                throw new ValidationException("Email and Password are mandatory");

            if (!_validationService.EmailIsValid(request.Email))
                throw new ValidationException("Invalid Email");

            if (!_validationService.PasswordIsValid(request.Password))
                throw new ValidationException("Invalid Password");

            var hashedPassword = _securityService.Hash(request.Password);

            var user = await _context.Users.Where(x => x.Email == request.Email && x.Password == hashedPassword).FirstOrDefaultAsync();
            if (user == null)
                throw new ValidationException("Wrong Credentials");

            var response = new AuthenticationResponse();
            response.User = user;
            response.AccessToken = this._securityService.GenerateJwtToken(user.UserId.ToString(), user.Email);
            return response;
        }
    }
}
