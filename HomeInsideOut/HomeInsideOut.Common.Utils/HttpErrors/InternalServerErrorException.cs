using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.Common.Utils.HttpErrors
{
    public class InternalServerErrorException : BaseException
    {
        public InternalServerErrorException() : base("Internal Server Error") {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        public InternalServerErrorException(string message) : base(message)
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }
    }
}
