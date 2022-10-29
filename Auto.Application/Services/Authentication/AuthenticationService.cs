using Auto.Application.Common.Errors;
using Auto.Application.Common.Interfaces.Authentication;
using Auto.Application.Common.Interfaces.Persistence;
using Auto.Domain.Common.Errors;
using Auto.Domain.Entities;
using Auto.InternalLib;

namespace Auto.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public ErrorOrNot<AuthenticationResult>Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validate the User does not exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            //throw new Exception("User with given email already exist");
            return Errors.UserError.DuplicateEmail;
        }
        // 2. Create User (generate unique Id) & Persist to DB
        var user = new User
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Password = password
        };
        _userRepository.Add(user);

        // 3. Create Jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }

    public ErrorOrNot<AuthenticationResult> Login(string email, string password)
    {
        // 1. Validate the User does not exist
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            //throw new Exception("User with given email does not exist");
            return Errors.AuthenticationError.InvalidCredentials;
        }

        // 2. Validate the password is correct
        if (user.Password != password)
        {
            //throw new Exception("Invalid password");
            return new[] { Errors.AuthenticationError.InvalidCredentials };

        }

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}