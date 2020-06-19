using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace VirtualPharmaRep.API.Middleware
{
    public class ExecutionTimeMeasureMiddleware
    {
        private const string ResponseHeaderResponseTime = "Response-Time-ms";
        private readonly RequestDelegate _next;

        public ExecutionTimeMeasureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
            var watch = new Stopwatch();
            watch.Start();
            context.Response.OnStarting(() => {
                watch.Stop();
                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;
                context.Response.Headers[ResponseHeaderResponseTime] = responseTimeForCompleteRequest.ToString();
                return Task.CompletedTask;
            });
            return _next(context);
        }
    }
}
