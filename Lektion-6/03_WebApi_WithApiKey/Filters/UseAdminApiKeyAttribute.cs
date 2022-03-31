using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _03_WebApi_WithApiKey.Filters
{
    public class UseAdminApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var apiKey = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>().GetValue<string>("AdminApiKey");

            if (!context.HttpContext.Request.Headers.TryGetValue("code", out var code))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!apiKey.Equals(code))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
