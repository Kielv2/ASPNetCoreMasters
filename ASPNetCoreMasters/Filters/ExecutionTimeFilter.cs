using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMasters.Filters
{
    public class ExecutionTimeFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            DateTime startTime = (DateTime)context.HttpContext.Items["StartTime"];
            Console.WriteLine("Total Elapsed Time for Request is : " + (startTime - DateTime.UtcNow).TotalMilliseconds);
            Console.WriteLine("Request Ended.");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("Request started in " + context.ActionDescriptor.DisplayName.ToString());
            context.HttpContext.Items["StartTime"] = DateTime.UtcNow;
        }
    }
}
