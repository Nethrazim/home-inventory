using Microsoft.AspNetCore.Http;
using Shared.Api.Responses;
using Shared.Utils.HttpErrors;
using System.Net;
using System.Text.Json;

namespace Shared.Api.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                string message = string.Empty;
                switch (error)
                {
                    case BaseException e:
                        response.StatusCode = (int)e.StatusCode;
                        message = e.Message;
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        message = error.Message;
                        break;
                }


                var result = JsonSerializer.Serialize(new BaseResponse() { Message = message, StatusCode = (HttpStatusCode)response.StatusCode });
                await response.WriteAsync(result);
            }
        }
    }
}
