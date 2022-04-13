using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class UseAdminApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = config.GetValue<string>("ApiKeys:AdminApiKey");

            if (!context.HttpContext.Request.Headers.TryGetValue("key", out var key))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!apiKey.Equals(key))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
