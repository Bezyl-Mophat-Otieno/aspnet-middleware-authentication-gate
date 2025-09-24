using AuthenticationGateMiddleware.Middlewares;

namespace AuthenticationGateMiddleware.Extensions;

public static class AuthenticationMiddlewareExtension
{

    public static IApplicationBuilder UseCustomAuth(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomAuthMiddleware>();
    }
    
}