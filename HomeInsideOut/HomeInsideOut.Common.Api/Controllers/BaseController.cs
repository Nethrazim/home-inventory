using AutoMapper;
using HomeInsideOut.Common.Api.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.Common.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status500InternalServerError)]
    public class BaseController<T> : ControllerBase
    {
        public readonly IMapper mapper;
        public readonly ILogger<T> logger;

        public BaseController(IMapper mapper, ILogger<T> logger)
        {
            this.mapper = mapper;
            this.logger = logger;
        }
    }
}
