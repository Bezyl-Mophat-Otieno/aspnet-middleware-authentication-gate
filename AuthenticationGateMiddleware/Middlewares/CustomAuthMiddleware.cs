namespace AuthenticationGateMiddleware.Middlewares;

public class CustomAuthMiddleware(RequestDelegate next, ILogger<CustomAuthMiddleware>logger)
{

    public async Task InvokeAsync(HttpContext context)
    {
        var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }
        var token = authHeader.Substring("Bearer ".Length);
        // Demo token validation
        if (token != "access-token")
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized");
            logger.LogTrace(
                "Unauthorized User: IP {ip}, Status Code {statuscode}.", 
                 context.Connection.RemotePort, context.Response.StatusCode
                );
            return;
        }
        
        await next(context);
        
        logger.LogInformation("Response sent with status {statusCode}", context.Response.StatusCode);
    }

}