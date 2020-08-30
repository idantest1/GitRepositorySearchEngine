using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace GitRepositoryAPI.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            int.TryParse(context.HttpContext.Items["UserId"]?.ToString(), out int userId);
            if (userId == 0)
            {
                context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(new { message = "Unauthorized" });
                return;
            }
        }
    }
}
