using HomeInsideOut.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
