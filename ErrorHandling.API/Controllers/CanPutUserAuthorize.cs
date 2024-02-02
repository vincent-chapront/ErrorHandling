using ErrorHandling.API.Filters;
using ErrorHandling.Service.Model.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ErrorHandling.API.Controllers;

public class CanPutUserAuthorize : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var exception = new ForbidException("Not allowed to add users");
        exception.Data.Add("path", context.HttpContext.Request.Path);

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
        //var exception = new BadRequestException("Invalid data");
        //foreach (var kvp in context.ActionDescriptor.Parameters)
        //{
        //    var k = kvp.Name;
        //    var v = context.HttpContext.Request.Query[kvp.Name];
        //    exception.Data.Add(k, v);
        //}
        var errors = context.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToArray();
        context.Result = FilterHelpers.BuildContentResult(exception, errors);
        //throw exception;
    }
}