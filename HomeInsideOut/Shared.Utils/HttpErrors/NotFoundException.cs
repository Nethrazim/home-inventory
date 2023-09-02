namespace Shared.Utils.HttpErrors
{
    public class NotFoundException : BaseException
    {
        public NotFoundException() : base("Not Found")
        {
            StatusCode = System.Net.HttpStatusCode.NotFound;
        }

        public NotFoundException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.NotFound;
        }
    }
}
