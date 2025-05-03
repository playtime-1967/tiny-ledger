using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TMM.API.Filters
{
    public class ExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ProblemDetails problemDetails;
            var exception = context.Exception;

            problemDetails = new ProblemDetails
            {
                Detail = exception.Message,
                Type = exception.GetType().Name,
                Instance = context.HttpContext.Request.Path,
                Status = StatusCodes.Status400BadRequest
            };

            context.Result = new ObjectResult(problemDetails);
            context.ExceptionHandled = true;
        }
    };
}
