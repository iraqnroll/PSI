using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Serilog;

namespace PSIShoppingEngine.Middlewares.LoggerMiddleware
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggerMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            if(endpoint != null)
            {
                var controllerActionDescriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();
                if(controllerActionDescriptor != null)
                {
                    var user = context.User.Identity.Name;
                    var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var controllerName = controllerActionDescriptor.ControllerName;
                    var actionName = controllerActionDescriptor.ActionName;
                    if(userId == null)
                    {
                        _logger.Information($"Guest user performed " + $"action {actionName} in controller {controllerName}");
                    }
                    else
                    {
                        _logger.Information($"{user} [id : {userId}] performed " + $"action {actionName} in controller {controllerName}");
                    }
                }
            }
            await _next(context);

            
        }
    }
}
