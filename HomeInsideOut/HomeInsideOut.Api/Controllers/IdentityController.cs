using AutoMapper;
using HomeInsideOut.Api.Entities.Requests;
using HomeInsideOut.Api.Entities.Responses;
using HomeInsideOut.BusinessLayer.Config;
using HomeInsideOut.BusinessLayer.DTOs;
using HomeInsideOut.BusinessLayer.Helpers;
using HomeInsideOut.BusinessLayer.Services;
using HomeInsideOut.Common.Api.Controllers;
using HomeInsideOut.Common.Utils.Helpers;
using HomeInsideOut.DataLayer.Data;
using HomeInsideOut.DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HomeInsideOut.Api.Controllers
{
    public class IdentityController : BaseController<IdentityController>
    {
        private JwtConfig JwtConfig { get; set; }
        private IUserService UserService { get; set; }
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
                Entity = await UserService.FindById(23, throwExceptionIfNotFound: true)
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