using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using MVC.Data;
using MVC.Middleware;
using MVC.Models;
using System.Data.Common;
using System.Globalization;

namespace MVC.Middleware
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ApplicationDbContext _db;

        public RequestLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ApplicationDbContext db)
        {
            var ip = httpContext.Connection.RemoteIpAddress.ToString();
            var url = httpContext.Request.GetDisplayUrl();

            var log = new RequestLog()
            {
                Date = DateTime.UtcNow,
                IpAddress = ip,
                Url = url,
            };

            db.RequestLogs.Add(log);
            db.SaveChanges();

            // Call the next delegate/middleware in the pipeline.
            await _next(httpContext);
        }
    }
}

public static class MyCustomMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLog(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestLogMiddleware>();
    }
}