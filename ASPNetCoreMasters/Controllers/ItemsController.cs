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
    public class ItemsController : ControllerBase
    {   
        public int Get(int id)
        {
            //var item = new ItemService();
            //var result = item.GetAll(id);

            return id;
        }

        public IActionResult Post(ItemCreateBindingModel itemCreateBidingModel)
        {
            var item = new ItemService();
            var itemDTO = new ItemDTO();
            itemDTO.Text = itemCreateBidingModel.Text;
            item.Save(itemDTO);

            return Ok();
        }


    }
}
