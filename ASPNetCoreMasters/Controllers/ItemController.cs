using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMasters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpGet("{userId}")]
        public IEnumerable<String> GetAll(int userId)
        {
            var item = new ItemService();
            var result = item.GetAll(userId);

            return result;
        }

    }
}
