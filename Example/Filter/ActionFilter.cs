using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Filter {
  public class ActionFilter : Attribute, IActionFilter {
    public void OnActionExecuted(ActionExecutedContext context) {
      //context.HttpContext.Response.WriteAsync("Executing AsyncActionFilter. \r\n");
    }

    public void OnActionExecuting(ActionExecutingContext context) { }
  }
  /// <summary>
  /// 非同步
  /// </summary>
  public class AsyncActionFilter : Attribute, IAsyncActionFilter {
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
      //await context.HttpContext.Response.WriteAsync("Executing AsyncActionFilter.");
      await next();
    }

  }
}
