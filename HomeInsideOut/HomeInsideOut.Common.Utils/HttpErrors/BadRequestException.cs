using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.Common.Utils.HttpErrors
{
    public class BadRequestException : BaseException
    {
        public BadRequestException() : base("Bad Request") {
            StatusCode = System.Net.HttpStatusCode.BadRequest;
        }

        public BadRequestException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest;
        }
    }
}
