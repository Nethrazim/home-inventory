using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Module.Identity.BusinessLayer.Services;
using Module.Identity.Entities.Model.Requests;
using Module.Identity.Entities.Responses;
using Shared.Api.Controllers;
using Shared.BusinessLayer.Config;

namespace Module.Identity.Controllers
{
    [Route("/api/identity/[controller]")]
    public class IdentityController : BaseController<IdentityController>
    {
        private IUserService UserService { get; set; }
        private JwtConfig JwtConfig { get; set; }
        public IdentityController(
            IUserService userService,
            IOptions<JwtConfig> jwtConfig, IMapper mapper, ILogger<IdentityController> logger)
            : base(mapper, logger)
        {
            JwtConfig = jwtConfig.Value;
            UserService = userService;
        }


        [HttpPost]
        [Route("authenticate")]
        public async Task<AuthenticateResponse> Authenticate([FromBody] AuthenticateRequest request)
        {
            AuthenticateResponse response = new AuthenticateResponse()
            {
                Entity = await UserService.GenerateTokenAsync(request.Username, request.Password)
            };

            return response;
        }

        [HttpPost]
        [Route("private")]
        [Authorize(Roles = "admin")]
        public string PrivateEndpoint()
        {
            return "Hello Private";
        }
    }
}
