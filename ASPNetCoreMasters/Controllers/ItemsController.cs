using ASPNetCoreMasters.BindingModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMasters.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {   
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("GetAll route");
        }

        [HttpGet("{itemId}")]
        public IActionResult Get(int itemId)
        {
            var itemService = new ItemService();
            itemService.GetItem(itemId);
            return Ok($"Get {itemId}");
        }

        [HttpGet("filterBy")]
        public IActionResult GetByFilters([FromQuery] Dictionary<string, string> filters)
        {
            return Ok($"GetByFilters");
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] ItemCreateBindingModel itemcreatemodel)
        {
            var itemService = new ItemService();
            var itemDTO = new ItemDTO();
            itemDTO.Text = itemcreatemodel.Text;
            itemService.Save(itemDTO);

            return Ok($"Post {itemcreatemodel.Id} - {itemcreatemodel.Text} ");
        }

        [HttpPut("{itemId}")]
        public IActionResult Put(int itemId, [FromBody] ItemUpdateBindingModel itemUpdateModel)
        {
            var itemService = new ItemService();
            var itemDTO = new ItemDTO();
            itemDTO.Text = itemUpdateModel.Text;
            itemService.Save(itemDTO);

            return Ok($"Put {itemId} - {itemUpdateModel.Text} ");
        }

        [HttpDelete("{itemId}")]
        public IActionResult Delete(int itemId)
        {
            return Ok($"Delete {itemId}");
        }

    }
}
