using GamesInfo.WebHost.Models;
using System.Net;

using static GamesInfo.WebHost.Helpers.ExceptionsHelper;

namespace GamesInfo.WebHost.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (!ExceptionsHttpStatusCodes.TryGetValue(exception.GetType(), out var statusCode))
            {
                statusCode = HttpStatusCode.InternalServerError;
            }

            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsync(
                new ErrorResponse()
                {
                    StatusCode = (int)statusCode,
                    StatusDescription = statusCode.ToString(),
                    Message = exception.Message
                }
                .ToString());
        }
    }
}
