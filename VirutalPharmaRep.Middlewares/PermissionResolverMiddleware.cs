using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using VirtualPharmaRep.Data.CustomObjects;

namespace VirtualPharmaRep.Middleware
{
    public class PermissionResolverMiddleware
    {
        private readonly RequestDelegate _next;

        public PermissionResolverMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();
            context.Request.Reqi
            //var type = Type.GetType($"VirtualPharmaRep.Data.Entities.{context.Request.RouteValues["controller"]}");
            context.Request.Body.Seek(0, SeekOrigin.Begin);
            using (var stream = new StreamReader(context.Request.Body,leaveOpen:true))
            {
                var body = await stream.ReadToEndAsync();
                Console.WriteLine(body);
            }
            context.Request.Body.Seek(0, SeekOrigin.Begin);
            

            await _next(context);
        }
    }
}
