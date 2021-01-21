using System.Web.Mvc;

namespace GCD0704.AppDev.FIlters
{
	public class AuthorizeOrForbidAttribute : AuthorizeAttribute
	{
		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			if (filterContext.HttpContext.User.Identity.IsAuthenticated)
			{
				filterContext.Result = new HttpStatusCodeResult(403);
			}
			else
			{
				filterContext.Result = new HttpUnauthorizedResult();
			}
		}
	}
}