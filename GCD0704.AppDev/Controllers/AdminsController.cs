using GCD0704.AppDev.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GCD0704.AppDev.Controllers
{
	[Authorize(Roles = "admin")]
	public class AdminsController : Controller
	{
		private ApplicationDbContext _context;
		public AdminsController()
		{
			_context = new ApplicationDbContext();
		}
		// GET: Admins
		public ActionResult Profiles()
		{
			var users = _context.Users
				.Include(u => u.Roles)
				.ToList();
			return View(users);
		}
	}
}