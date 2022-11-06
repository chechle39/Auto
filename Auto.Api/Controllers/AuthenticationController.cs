using Auto.Api.Fillters;
using Auto.Contracts.Authentication;
using Auto.InternalLib;
using Microsoft.AspNetCore.Mvc;
using Auto.Domain.Common.Errors;
using MediatR;
using Auto.Application.Authentication.Commands.Register;
using Auto.Application.Authentication.Common;
using Auto.Application.Authentication.Queries.Login;
using MapsterMapper;

namespace Auto.Api.Controllers;
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public AuthenticationController(ISender mediator, IMapper mapper) 
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
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