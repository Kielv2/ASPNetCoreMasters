using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMasters.Filters
{
    public class EnsureItemIdExistFilter : IActionFilter
    {
        private readonly IItemService _itemService;
        public EnsureItemIdExistFilter(IItemService itemService)
        {
            _itemService = itemService;
        }
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var itemId = (int)context.ActionArguments["itemId"];
            var isExist = _itemService.Get(itemId);
            if (isExist == null)
            {
                context.Result = new NotFoundResult();
            }
        }
    }
    public class EnsureItemIdExistFilterAttribute : TypeFilterAttribute
    {
        public EnsureItemIdExistFilterAttribute() : base(typeof(EnsureItemIdExistFilter))
        {
        }
    }
}