using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.Portal.Core.Data;
using Tahaluf.Portal.Core.Repositry;
using Tahaluf.Portal.Core.Services;

namespace Tahaluf.Portal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : Controller
    {
        private readonly IJwtUserAuthService JwtUserAuthService;
        public UserAuthController(IJwtUserAuthService jwtUserAuthService)
        {
            JwtUserAuthService = jwtUserAuthService;
        }
        [HttpPost]
        [Route("Authenticate")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(User), StatusCodes.Status400BadRequest)]
        public IActionResult Authenticate([FromBody] User user)
        {
            var token = JwtUserAuthService.Authenticate(user);
            if (token == null)
                return Unauthorized();
            else
                return Ok(token);
        }
    }
}
