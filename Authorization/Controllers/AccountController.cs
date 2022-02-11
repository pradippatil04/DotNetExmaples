using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]")]
        public async Task<IActionResult> Login(string username, string password)
        {
            if(username == "pradip" && password == "password")
            {

                //var claims = new List<Claim>()
                //{
                //    new Claim("user" , "pradip"),
                //    new Claim("canRead" , "Y")
                //};
                //await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "user", null)));

                return Ok(username);

            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(AuthenticationSchemes = "MyScheme")]
        [HttpGet]
        [Route("[action]")]
        public  IActionResult GetProtected()
        {
            var cookie = HttpContext.Request.Cookies["auth_cookie"];
            return Ok("yes");
        }
    }
}
