using System.Net;

namespace Shared.Api.Responses
{
    public class BaseResponse
    {
        public string Message { get; set; } = "Operation completed";
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool HasError => StatusCode != HttpStatusCode.OK;
    }
}