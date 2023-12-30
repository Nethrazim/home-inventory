using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Module.Identity.BusinessLayer.Services;
using Module.Identity.Entities.Model;
using Module.Identity.Entities.Model.Requests;
using Module.Identity.Entities.Responses;
using Shared.Api.Controllers;
using Shared.BusinessLayer.Config;
using System.Reflection.Metadata.Ecma335;

namespace Module.Identity.Controllers
{
    [Route("/api/identity/[controller]")]
    public class AccountController : BaseController<AccountController>
    {
        private IUserService UserService { get; set; }
        private JwtConfig JwtConfig { get; set; }
        public AccountController(
            IUserService userService,
            IOptions<JwtConfig> jwtConfig, IMapper mapper, ILogger<AccountController> logger)
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
                Entity = new TokenModel() 
                { 
                    Value = await UserService.
                        GenerateTokenAsync(request.Email, request.Password) 
                }
            };

            return response;
        }

        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public async Task<CreateAccountResponse> CreateAccount(CreateAccountRequest request)
        {
            CreateAccountResponse response = new CreateAccountResponse()
            {
                Value = await UserService.CreateAccountAsync(request.Username, request.Email, request.Password)
            };

            return response;
        }
    }
}
