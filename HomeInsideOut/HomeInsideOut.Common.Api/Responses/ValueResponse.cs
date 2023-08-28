using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.Common.Api.Responses
{
    public class ValueResponse<T> : BaseResponse
        where T: struct
    {
        public T Value { get; set; }
    }
}
