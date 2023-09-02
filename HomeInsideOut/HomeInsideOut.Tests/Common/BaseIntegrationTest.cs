using HomeInsideOut.Tests.Helpers;

namespace HomeInsideOut.Tests.Common
{
    public class BaseIntegrationTest
    {
        public RequestHelper requestHelper { get; set; }
        public BaseIntegrationTest(HttpClient httpClient)
        {
            requestHelper = new RequestHelper(httpClient);
        }
    }
}
