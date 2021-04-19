using GeoCab.WEB.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GeoCab.WEB.Controllers.CustomFilterAttributes
{
	public class IsEmployeeAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			var userService = context.HttpContext.RequestServices.GetService(typeof(UserMiddleware)) as UserMiddleware;
			
			if (!userService.IsEmployee())
			{
				context.Result = new ForbidResult();
			}
			
			base.OnActionExecuted(context);
		}
	}
}