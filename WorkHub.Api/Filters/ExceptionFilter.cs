using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WorkHub.Exceptions;
using WorkHub.Exceptions.Base;

namespace WorkHub.Api.Filters;
public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BaseException baseException)
        {
            context.HttpContext.Response.StatusCode = (int)baseException.GetStatusCode();
            context.Result = new ObjectResult(context.Exception.Message);
            Console.WriteLine($"Exception Filter: Base Exception - StatusCode: {context.HttpContext.Response.StatusCode} - {ResourceErrorMessages.UNKNOWN_ERROR} - Message: {context.Exception.Message}");
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(string.Concat(ResourceErrorMessages.UNKNOWN_ERROR, "\nDetalhes: ", context.Exception.InnerException?.Message ?? context.Exception.Message));
            Console.WriteLine($"Exception Filter: System Exception - StatusCode: {context.HttpContext.Response.StatusCode} - {ResourceErrorMessages.UNKNOWN_ERROR} - Message: {context.Exception.Message}");
        }
    }
}