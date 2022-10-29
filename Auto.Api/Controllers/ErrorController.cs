using Auto.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Auto.Api.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exeption = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            var (statusCode, message) = exeption switch
            {
                DuplicateEmailException => (StatusCodes.Status409Conflict, "Email already exist"),
                _ => (StatusCodes.Status500InternalServerError, "An exception error occured")
            };
            return Problem(statusCode: statusCode, title: message);
            //return Problem(title: exeption?.Message,statusCode: 400);
        }
    }
}
