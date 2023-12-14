namespace Shared.Utils.HttpErrors
{
    public class NotAuthorizedException : BaseException
    {
        public NotAuthorizedException() : base("Not Authorized")
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized;
        }

        public NotAuthorizedException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized;
        }
    }
}
