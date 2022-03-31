using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _03_WebApi_WithApiKey.Filters
{
    public class UseApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var apiKey = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>().GetValue<string>("UserApiKey");

            // Query = parameter i url       ex. https://domain.com/api/products?code=
            // Koden nedan beskriver vad som händer om vi inte hittar code som parameter i urlen
            if (!context.HttpContext.Request.Query.TryGetValue("code", out var code))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // Koden nedan beskriver vad som händer om nyckeln i code inte stämmer överens med det vi har i vår apiKey
            if(!apiKey.Equals(code))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();

        }
    }
}
