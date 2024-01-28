using ErrorHandling.Service.Model.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ErrorHandling.API.Filters
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.HttpContext.Response.StatusCode = 400;
                var exception = new BadRequestException("Invalid data");
                foreach (var kvp in context.ActionArguments)
                {
                    exception.Data.Add(kvp.Key, kvp.Value);
                }
                var errors = context.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToArray();
                context.Result = FilterHelpers.BuildContentResult(exception, errors);
            }
        }
    }
}