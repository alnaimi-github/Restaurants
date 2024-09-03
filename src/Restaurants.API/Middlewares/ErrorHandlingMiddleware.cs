using Restaurants.Domain.Exceptions;

namespace Restaurants.API.Middlewares;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger):IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException notFound)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync(notFound.Message);
            logger.LogWarning(notFound.Message);
        }
        catch (ForbidException)
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Access forbidden!");
        }
        catch (Exception e)
        {
           logger.LogError(e,e.Message);
           context.Response.StatusCode = StatusCodes.Status500InternalServerError;
          await context.Response.WriteAsync("Something went wrong!"+e.Message);
        }
    }
}