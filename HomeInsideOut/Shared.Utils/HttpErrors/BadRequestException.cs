namespace Shared.Utils.HttpErrors
{
    public class BadRequestException : BaseException
    {
        public BadRequestException() : base("Bad Request")
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest;
        }

        public BadRequestException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest;
        }
    }
}
