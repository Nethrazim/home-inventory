using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.Common.Api.Responses
{
    public class EntityResponse<T> : BaseResponse
        where T: class
    {
        public T Entity { get; set; }
    }
}
