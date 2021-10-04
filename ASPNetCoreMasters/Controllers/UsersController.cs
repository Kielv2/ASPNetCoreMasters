using ASPNetCoreMasters.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMasters.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private AuthenticationSettings _authSettings;
        public UsersController(IOptionsSnapshot<AuthenticationSettings> options)
        {
            _authSettings = options.Value;
            
        }

        [HttpGet]
        public IActionResult Login()
        {
            return Ok(_authSettings.JWT);
        }
    }
}
