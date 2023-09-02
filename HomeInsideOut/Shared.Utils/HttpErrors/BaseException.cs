using System.Net;

namespace Shared.Utils.HttpErrors
{
    public class BaseException : Exception
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public BaseException(string message) : base(message)
        {
            Message = message;
        }
    }
}
