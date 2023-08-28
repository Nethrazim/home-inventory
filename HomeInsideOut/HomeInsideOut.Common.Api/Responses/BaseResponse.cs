using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.Common.Api.Responses
{
    public class BaseResponse
    {
        public string Message { get; set; } = null!;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool HasError => StatusCode != HttpStatusCode.OK;
    }
}