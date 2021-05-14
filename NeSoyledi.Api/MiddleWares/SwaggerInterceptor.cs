using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace NeSoyledi.Api.MiddleWares
{
    public class SwaggerInterceptor
    {
        private readonly RequestDelegate _next;

        public SwaggerInterceptor(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Path.StartsWithSegments("/swagger") || !context.Request.Path.StartsWithSegments("/") || !context.Request.Path.StartsWithSegments("/index.html"))
            {
                var param = context.Request.QueryString.Value;

                if (!param.Equals("?key=9a92661b70c983be53143d7600bc2284"))
                {
                    context.Response.StatusCode = 404;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync("{\"result:\" \"Not Found\"}", Encoding.UTF8);
                    return;
                }
            }

            await _next.Invoke(context);
        }
    }
}
