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
using ASPNetCoreMasters.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ASPNetCoreMasters.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnsureItemIdExistFilter]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly UserManager<IdentityUser> _userService;
        private readonly IAuthorizationService _authService;

        public ItemsController(IItemService itemService, UserManager<IdentityUser> userService, IAuthorizationService authService)
        {
            _itemService = itemService;
            _userService = userService;
            _authService = authService;
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

            var result = _itemService.Get(itemId);
            return Ok(result);
        }

        [HttpGet("filterBy")]
        public IActionResult GetByFilters([FromQuery] Dictionary<string, string> filters)
        {
            var filter = filters["Text"].ToString();
            var filterDTO = new ItemByFilterDTO();
            filterDTO.Text = filter;
           
            var result = _itemService.GetAllByFilter(filterDTO);
            return Ok(result);
        }

        [HttpPost]

        public async Task<IActionResult> PostAsync([FromBody] ItemCreateBindingModel itemCreateModel)
        {
            var email = ((ClaimsIdentity)User.Identity).Name;
            ItemDTO requestData = new ItemDTO() { Id = itemCreateModel.Id, Text = itemCreateModel.Text };
            _itemService.Add(requestData);
            return Ok(requestData);
        }

        [HttpPut("{itemId}")]
        public async Task<IActionResult> PutAsync(int itemId, [FromBody] ItemUpdateBindingModel itemUpdateModel)
        {
            var itemVM = _itemService.Get(itemUpdateModel.ItemId);
            var authResult = await _authService.AuthorizeAsync(User, new ItemDTO() { CreatedBy = itemVM.CreatedBy }, "CanEditItems");
            if (!authResult.Succeeded)
            {
                return new ForbidResult();
            }
            ItemDTO requestData = new ItemDTO() { Id = itemUpdateModel.ItemId, Text = itemUpdateModel.Text };

            _itemService.Update(requestData);
            return Ok(requestData);
        }

        [HttpDelete("{itemId}")]
        public IActionResult Delete(int itemId)
        {
            _itemService.Delete(itemId);
            return Ok();
        }

    }
}
