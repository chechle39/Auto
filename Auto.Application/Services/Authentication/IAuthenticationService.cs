using Auto.InternalLib;

namespace Auto.Application.Services.Authentication;
public interface IAuthenticationService 
{
    ErrorOrNot<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    ErrorOrNot<AuthenticationResult> Login(string email, string password);
}