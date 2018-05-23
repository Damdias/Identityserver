using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCore.Auth.Web.Controllers
{
   // [Produces("application/json")]
    [Route("api")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ApiController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        [Route("user")]
        public IActionResult GetUserInformation()
        {
            return Ok(new
            {
                id = User.FindFirst("sub").Value,
                userName = User.Identity.Name
            });
        }

    }
}
