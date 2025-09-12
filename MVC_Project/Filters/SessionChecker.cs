using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC_Project.Filters
{
    public class SessionChecker : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool is_skipper_active = context.ActionDescriptor.EndpointMetadata.OfType<SkipSessionChecker>().Any();

            if (is_skipper_active)
                return;


            var session = context.HttpContext.Session;
            var userID = session.GetString("UserId");

            if (string.IsNullOrEmpty(userID))
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }


        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class SkipSessionChecker : Attribute
    {

    }


}
