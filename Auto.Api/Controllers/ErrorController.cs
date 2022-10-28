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
            return Problem(title: exeption?.Message,statusCode: 400);
        }
    }
}
