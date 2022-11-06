using Auto.Application.Services.Authentication.Common;
using Auto.InternalLib;

namespace Auto.Application.Services.Authentication.Queries;
public interface IAuthenticationQueryService
{
    //ErrorOrNot<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    ErrorOrNot<AuthenticationResult> Login(string email, string password);
}