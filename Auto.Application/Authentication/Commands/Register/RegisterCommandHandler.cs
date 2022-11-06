using Auto.Application.Common.Interfaces.Authentication;
using Auto.Application.Common.Interfaces.Persistence;
using Auto.Domain.Entities;
using Auto.InternalLib;
using MediatR;
using Auto.Domain.Common.Errors;
using Auto.Application.Authentication.Common;

namespace Auto.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOrNot<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public async Task<ErrorOrNot<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            // 1. Validate the User does not exist
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                //throw new Exception("User with given email already exist");
                return Errors.UserError.DuplicateEmail;
            }
            // 2. Create User (generate unique Id) & Persist to DB
            var user = new User
            {
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Password = command.Password
            };
            _userRepository.Add(user);

            // 3. Create Jwt token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
