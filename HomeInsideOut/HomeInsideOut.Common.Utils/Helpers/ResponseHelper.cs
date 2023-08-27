using HomeInsideOut.Common.Utils.HttpErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.Common.Utils.Helpers
{
    public static class ResponseHelper
    {
        public static void ReturnNotFound(string message) { 
            throw new NotFoundException(message);
        }

        public static void ReturnBadRequest(string message) {
            throw new BadRequestException(message);
        }
    }
}
