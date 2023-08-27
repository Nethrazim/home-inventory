using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.Common.Utils.HttpErrors
{
    public class NotFoundException : BaseException
    {
        public NotFoundException() : base("Not Found") {
            StatusCode = System.Net.HttpStatusCode.NotFound;
        }

        public NotFoundException(string message) : base(message) {
            StatusCode = System.Net.HttpStatusCode.NotFound;
        }
    }
}
