using ErrorHandling.Service.Model.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ErrorHandling.API.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    private readonly IHostEnvironment _hostEnvironment;

    public GlobalExceptionFilter(IHostEnvironment hostEnvironment) =>
        _hostEnvironment = hostEnvironment;

    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ForbidException)
        {
            context.HttpContext.Response.StatusCode = 403;
        }

        if (context.Exception is BadRequestException)
        {
            context.HttpContext.Response.StatusCode = 400;
        }

        if (context.Exception is NotFoundException)
        {
            context.HttpContext.Response.StatusCode = 404;
        }
        context.Result = FilterHelpers.BuildContentResult(context.Exception, new string[] { context.Exception.Message }, _hostEnvironment.IsDevelopment());
    }
}