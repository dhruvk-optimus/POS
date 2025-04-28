using System.Diagnostics;

namespace POS.API.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            _logger.LogInformation("Incoming Request: {Timestamp} {Method} {Path}",
                DateTime.UtcNow, context.Request.Method, context.Request.Path);

            await _next(context);

            stopwatch.Stop();
  
            _logger.LogInformation("Outgoing Response: {Timestamp} {Method} {Path} responded {StatusCode} in {ElapsedMilliseconds}ms",
                DateTime.UtcNow, context.Request.Method, context.Request.Path, context.Response.StatusCode, stopwatch.ElapsedMilliseconds);
        }
    }
}
