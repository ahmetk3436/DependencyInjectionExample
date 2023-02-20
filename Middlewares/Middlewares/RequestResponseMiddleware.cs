using Microsoft.Extensions.Logging;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Middlewares.Middlewares
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public RequestResponseMiddleware(RequestDelegate next,ILogger<RequestResponseMiddleware> Logger)
        {
            this.next = next;
            logger = Logger;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            // Request
            logger.LogInformation($"Query Keys: {String.Join(",", httpContext.Request.Query)}");

            // Buffer the response
            var buffer = new MemoryStream();
            var stream = httpContext.Response.Body;
            httpContext.Response.Body = buffer;

            await next.Invoke(httpContext); // Response

            // Read the buffered response
            buffer.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(buffer, Encoding.UTF8);
            var responseBody = await reader.ReadToEndAsync();

            // Log the response
            logger.LogInformation($"Response Body: {responseBody}");

            // Copy the buffered response to the original stream
            buffer.Seek(0, SeekOrigin.Begin);
            await buffer.CopyToAsync(stream);
            httpContext.Response.Body = stream;
        }

    }
}
