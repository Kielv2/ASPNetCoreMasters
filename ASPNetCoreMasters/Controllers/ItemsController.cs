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
    public class ItemsController : ControllerBase
    {   
        [HttpGet]
        [Route("/items")]
        public IActionResult GetAll()
        {
            return Ok("GetAll route");
        }

        [HttpGet]
        [Route("/items/{itemId}")]
        public IActionResult Get(int itemId)
        {
            var itemService = new ItemService();
            itemService.GetItem(itemId);
            return Ok($"Get {itemId}");
        }

        [HttpGet]
        [Route("/items/filterBy?[text]={text}")]
        public IActionResult GetByFilters([FromQuery] Dictionary<string, string> filters)
        {
            return Ok($"GetByFilters {filters}");
        }

        [HttpPost]
        [Route("/items")]
        public IActionResult Post([FromBody] ItemCreateBindingModel itemcreatemodel)
        {
            var itemService = new ItemService();
            var itemDTO = new ItemDTO();
            itemDTO.Text = itemcreatemodel.Text;
            itemService.Save(itemDTO);

            return Ok($"Post {itemcreatemodel}");
        }

        [HttpPut]
        [Route("/items/itemId")]
        public IActionResult Put(int id, [FromBody] ItemUpdateBindingModel itemUpdateModel)
        {
            var itemService = new ItemService();
            var itemDTO = new ItemDTO();
            itemDTO.Text = itemUpdateModel.Text;
            itemService.Save(itemDTO);

            return Ok($"Put {itemUpdateModel}");
        }

        [HttpDelete]
        [Route("/items/itemId")]
        public IActionResult Put(int itemId)
        {
            return Ok($"Delete {itemId}");
        }

    }
}
