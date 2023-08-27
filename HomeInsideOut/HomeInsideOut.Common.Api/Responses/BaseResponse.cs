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
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool HasError => StatusCode != HttpStatusCode.OK;
        public BaseResponse(string message, HttpStatusCode statusCode) { 
            Message = message;
            StatusCode = statusCode;
        }
    }
}
