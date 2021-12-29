using _57Blocks.domain.DataBase;
using _57Blocks.domain.Features.Commands;
using _57Blocks.domain.Features.Responses;
using _57Blocks.domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _57Blocks.domain.Features.Handlers
{
    public class RegistrationHandler : IRequestHandler<RegistrationCommand, AuthenticationResponse>
    {
        private DBContext _context;
        private I57BlocksSecurityService _securityService;
        private IValidationService _validationService;

        public RegistrationHandler(DBContext context, I57BlocksSecurityService securityService, IValidationService validationService)
        {
            _context = context;
            _securityService = securityService;
            _validationService = validationService;
        }

        public async Task<AuthenticationResponse> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                throw new ValidationException("Email and Password are mandatory");

            if (!_validationService.EmailIsValid(request.Email))
                throw new ValidationException("Invalid Email");

            if (!_validationService.PasswordIsValid(request.Password))
                throw new ValidationException("Invalid Password");

            var existentUser = await _context.Users.Where(x => x.Email == request.Email).FirstOrDefaultAsync();
            if (existentUser != null)
                throw new ValidationException("A user already exist with this email");

            var user = new User()
            {
                UserId = Guid.NewGuid(),
                Email = request.Email,
                Password = _securityService.Hash(request.Password)
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var response = new AuthenticationResponse();
            response.User = user;
            response.AccessToken = this._securityService.GenerateJwtToken(user.UserId.ToString(), user.Email);
            return response;
        }
    }
}
