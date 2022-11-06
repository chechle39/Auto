using Auto.Application.Authentication.Commands.Register;
using Auto.Application.Authentication.Common;
using Auto.Application.Common.Interfaces.Authentication;
using Auto.Application.Common.Interfaces.Persistence;
using Auto.Domain.Common.Errors;
using Auto.Domain.Entities;
using Auto.InternalLib;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOrNot<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public async Task<ErrorOrNot<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            // 1. Validate the User does not exist
            if (_userRepository.GetUserByEmail(request.Email) is not User user)
            {
                //throw new Exception("User with given email does not exist");
                return Errors.AuthenticationError.InvalidCredentials;
            }

            // 2. Validate the password is correct
            if (user.Password != request.Password)
            {
                //throw new Exception("Invalid password");
                return new[] { Errors.AuthenticationError.InvalidCredentials };

            }

            // 3. Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
