using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Auto.Api.Fillters
{
    public class ErrorHandlingFilterAttribte : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occuured while processing your request.",
                Status = (int)HttpStatusCode.InternalServerError
            };
            //context.Result = new ObjectResult(new { error = "An error occuured while processing your request." })
            //{
            //    StatusCode = 500
            //};
            context.Result = new ObjectResult(problemDetails);
            context.ExceptionHandled = true;
        }
    }
}
