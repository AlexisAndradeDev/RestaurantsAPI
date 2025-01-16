
using System.Diagnostics;

namespace Restaurants.API.Middlewares;

public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var stopWatch = Stopwatch.StartNew();
        await next.Invoke(context);
        stopWatch.Stop();

        var elapsedTime = stopWatch.ElapsedMilliseconds;
        if (elapsedTime / 1000 > 4) { }
            logger.LogInformation("[{HttpMethod}] {Path} took {Time} ms", 
                context.Request.Method,
                context.Request.Path,
                elapsedTime);
    }
}
