using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.Common.Utils.HttpErrors
{
    public class BaseException : Exception
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public BaseException(string message) : base(message) {
            Message = message;
        }
    }
}
