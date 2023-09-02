using System.Net;

namespace Shared.Utils.HttpErrors
{
    public class InternalServerErrorException : BaseException
    {
        public InternalServerErrorException() : base("Internal Server Error")
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        public InternalServerErrorException(string message) : base(message)
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }
    }
}
