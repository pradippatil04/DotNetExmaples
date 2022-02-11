using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFilters.Filters
{
    public class MyResourceFilter : IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("OnResourceExecuting");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
          
        }

    }
}
