using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oordring.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Oordring.Api.Inerfaces;
namespace Oordring.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        private IUserService _userService;
      
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public IActionResult Authenticate([FromBody] User userParam)
        {
            //var user = _context.users.FirstOrDefault(x => x.Username == userParam.Username && x.Password == userParam.Password);
            var user = _userService.Authenticate(userParam.Username, userParam.Password);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


      
    }
}
