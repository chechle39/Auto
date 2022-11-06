using Auto.Api.Fillters;
using Auto.Contracts.Authentication;
using Auto.InternalLib;
using Microsoft.AspNetCore.Mvc;
using Auto.Domain.Common.Errors;
using MediatR;
using Auto.Application.Authentication.Commands.Register;
using Auto.Application.Authentication.Common;
using Auto.Application.Authentication.Queries.Login;

namespace Auto.Api.Controllers;
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator) 
    {
        _mediator = mediator;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        ErrorOrNot<AuthenticationResult> authResult = await _mediator.Send(command);
   
        return authResult.Match(
          authResult => Ok(MapAuthResult(authResult)),
          errors => Problem(errors)
          );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var authResult = await _mediator.Send(query);
        if (authResult.IsError && authResult.FirstError == Errors.AuthenticationError.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }
        return authResult.Match(
           authResult => Ok(MapAuthResult(authResult)),
           errors => Problem(errors)
           );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
                    authResult.user.Id,
                    authResult.user.FirstName,
                    authResult.user.LastName,
                    authResult.user.Email,
                    authResult.Token
                );
    }
}