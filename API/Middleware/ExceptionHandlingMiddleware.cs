using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace API.Middleware
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (OperationCanceledException ex) when (!context.Response.HasStarted)
            {
                logger.LogWarning(ex, "Timeout or canceling");
                context.Response.StatusCode = StatusCodes.Status504GatewayTimeout;
                await context.Response.WriteAsync("Timeout");
            }
            catch (Exception ex) when (!context.Response.HasStarted)
            {
                logger.LogError(ex, "Unhandled exception");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Internal Server Error");
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Unhandled after response started. Rethrowing...");
                throw;
            }
        }
    }

}
