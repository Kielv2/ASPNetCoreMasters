using ASPNetCoreMasters.BindingModels;
using DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
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
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _itemService.GetAll();
            return Ok(result);
        }

        [HttpGet("{itemId}")]
        public IActionResult Get(int itemId)
        {
            if (String.IsNullOrEmpty(itemId.ToString()))
            {
                return BadRequest("Invalid Input");
            }

            var result = _itemService.Get(itemId);
            return Ok(result);
        }

        [HttpGet("filterBy")]
        public IActionResult GetByFilters([FromQuery] Dictionary<string, string> filters)
        {
            var filter = filters.FirstOrDefault(x => x.Value == "1").Value;
            var filterDTO = new ItemByFilterDTO();
            filterDTO.Text = filter;

            _itemService.GetAllByFilter(filterDTO);
            return Ok($"GetByFilters");
        }

        [HttpPost]
        public IActionResult Post([FromBody] ItemCreateBindingModel itemcreatemodel)
        {

            var itemDTO = new ItemDTO();
            itemDTO.Text = itemcreatemodel.Text;
            _itemService.Add(itemDTO);

            return Ok($"Post {itemcreatemodel.Id} - {itemcreatemodel.Text} ");
        }

        [HttpPut("{itemId}")]
        public IActionResult Put(int itemId, [FromBody] ItemUpdateBindingModel itemUpdateModel)
        {
            var itemDTO = new ItemDTO();
            itemDTO.Text = itemUpdateModel.Text;
            _itemService.Update(itemDTO);

            return Ok($"Put {itemId} - {itemUpdateModel.Text} ");
        }

        [HttpDelete("{itemId}")]
        public IActionResult Delete(int itemId)
        {
            _itemService.Delete(itemId);
            return Ok();
        }

    }
}
