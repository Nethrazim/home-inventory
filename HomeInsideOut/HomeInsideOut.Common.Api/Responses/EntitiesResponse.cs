using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.Common.Api.Responses
{
    public class EntitiesResponse<T>: BaseResponse
    {
        public List<T> Entities { get; set; }
    }
}
