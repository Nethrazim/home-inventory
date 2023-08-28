using AutoMapper;
using HomeInsideOut.BusinessLayer.DTOs;
using HomeInsideOut.Common.Api.Controllers;
using HomeInsideOut.Common.Utils.Helpers;
using HomeInsideOut.DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeInsideOut.Api.Controllers
{
    public class IdentityController : BaseController<IdentityController>
    {
        public IdentityController(IMapper mapper, ILogger<IdentityController> logger) : base(mapper, logger){ 
        } 


        [HttpGet]
        [Route("authenticate")]
        public IEnumerable<string> Get()
        {
            mapper.Map<UserDTO>(new User());
            ResponseHelper.ReturnNotFound("Customer id not found");
            return Enumerable.Range(1, 5).Select(index => index.ToString()
            ).ToArray();
        }
    }
}