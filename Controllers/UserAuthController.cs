using AngularChallengeAPI.Models;
using AngularChallengeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserAuthController : ControllerBase
    {
        private IUserService _userService;

        public UserAuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Email, userParam.Wachtwoord);
            if (user == null)
                return BadRequest(new { message = "Email of wachtwoord is fout" });
            return Ok(user);
        }
    }
}
