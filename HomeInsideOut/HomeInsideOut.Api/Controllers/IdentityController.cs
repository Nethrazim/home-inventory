using AutoMapper;
using HomeInsideOut.Api.Entities.Requests;
using HomeInsideOut.Api.Entities.Responses;
using HomeInsideOut.BusinessLayer.DTOs;
using HomeInsideOut.Common.Api.Controllers;
using HomeInsideOut.Common.Utils.Helpers;
using HomeInsideOut.DataLayer.Data;
using HomeInsideOut.DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeInsideOut.Api.Controllers
{
    public class IdentityController : BaseController<IdentityController>
    {
        private HomeInsideOutContext Context { get; set; }
        public IdentityController(IMapper mapper, ILogger<IdentityController> logger, HomeInsideOutContext context) 
            : base(mapper, logger)
        {
            Context = context;
        } 


        [HttpGet]
        [Route("authenticate")]
        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            var users = Context.Users.ToList();

            AuthenticateResponse response = new AuthenticateResponse()
            {
                Entities = mapper.Map<List<UserDTO>>(users)
            };

            return response; 
        }
    }
}