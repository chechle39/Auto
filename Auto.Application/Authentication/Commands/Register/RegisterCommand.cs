using Auto.Application.Authentication.Common;
using Auto.InternalLib;
using MediatR;

namespace Auto.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password
        ) : IRequest<ErrorOrNot<AuthenticationResult>>;
}
