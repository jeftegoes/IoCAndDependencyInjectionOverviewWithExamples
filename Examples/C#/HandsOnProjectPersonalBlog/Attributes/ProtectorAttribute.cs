using HandsOnProjectPersonalBlog.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HandsOnProjectPersonalBlog.Attributes
{
    public class ProtectorAttribute : Attribute, IActionFilter
    {
        private readonly IAuthorizerService _authorizerService;

        public ProtectorAttribute(IAuthorizerService authorizerService)
        {
            _authorizerService = authorizerService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!_authorizerService.IsAuthorized())
            {
                context.Result = new RedirectToActionResult("Error", "Home", null);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // throw new NotImplementedException();
        }
    }
}