using Serilog.Context;
using System.Security.Claims;

namespace QuizManagement.API.Middleware;

public class LoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHttpContextAccessor _contextAccessor;
    public LoggerMiddleware(RequestDelegate next, IHttpContextAccessor contextAccessor)
    {
        _next = next;
        _contextAccessor = contextAccessor;
    }
    //public async Task InvokeAsync(HttpContext context)
    //{
    //    using (LogContext.PushProperty("MethodType", context.Request.Method))
    //    using (LogContext.PushProperty("Path", context.Request.Path))
    //    {
    //        // Process the request
    //        await _next(context);
    //    }
    //}
    public async Task InvokeAsync(HttpContext context)
    {
        LogContext.PushProperty("UserName", _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name) ?? "System");
        LogContext.PushProperty("MethodType", context.Request.Method);
        LogContext.PushProperty("MethodName", context.Request.Path);
        await _next(context);
    }

}
