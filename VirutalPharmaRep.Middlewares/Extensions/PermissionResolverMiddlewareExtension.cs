using Microsoft.AspNetCore.Builder;

namespace VirtualPharmaRep.Middleware.Extensions
{
    public static class PermissionResolverMiddlewareExtension
    {
        public static IApplicationBuilder UsePermissionResolver(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PermissionResolverMiddleware>();
        }
    }
}
