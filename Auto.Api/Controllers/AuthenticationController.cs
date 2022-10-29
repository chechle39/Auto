using Auto.Api.Fillters;
using Auto.Contracts.Authentication;
using Auto.InternalLib;
using Microsoft.AspNetCore.Mvc;
using Auto.Domain.Common.Errors;
using Auto.Application.Services.Authentication.Commands;
using Auto.Application.Services.Authentication.Common;
using Auto.Application.Services.Authentication.Queries;

namespace Auto.Api.Controllers;
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationCommandService _authenticationCommandService;
    private readonly IAuthenticationQueryService _authenticationQueryService;

    public AuthenticationController(IAuthenticationCommandService authenticationCommandService, IAuthenticationQueryService authenticationQueryService) 
    {
        _authenticationCommandService = authenticationCommandService;
        _authenticationQueryService = authenticationQueryService;
    }
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOrNot<AuthenticationResult> authResult = _authenticationCommandService.Register(request.FirstName, request.LastName, request.Email, request.Password);
   
        return authResult.Match(
          authResult => Ok(MapAuthResult(authResult)),
          errors => Problem(errors)
          );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationQueryService.Login(request.Email, request.Password);
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