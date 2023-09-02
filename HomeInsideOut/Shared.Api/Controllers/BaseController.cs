using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.Api.Responses;

namespace Shared.Api.Controllers
{
    [ApiController]
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
