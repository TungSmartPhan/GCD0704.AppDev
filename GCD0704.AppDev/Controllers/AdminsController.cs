﻿using GCD0704.AppDev.Models;
using GCD0704.AppDev.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GCD0704.AppDev.Controllers
{
	[Authorize(Roles = "admin")]
	public class AdminsController : Controller
	{
		private ApplicationDbContext _context;
		private UserManager<ApplicationUser> _userManager;
		public AdminsController()
		{
			_context = new ApplicationDbContext();
			_userManager = new UserManager<ApplicationUser>(
				new UserStore<ApplicationUser>(new ApplicationDbContext())
			);

		}
		// GET: Admins
		public ActionResult Profiles()
		{
			var users = _context.Users
				.ToList();

			List<UserWithRoleViewModel> usersWithRole = new List<UserWithRoleViewModel>();

			foreach (var user in users)
			{
				usersWithRole.Add(new UserWithRoleViewModel()
				{
					UserName = user.UserName,
					RoleName = _userManager.GetRoles(user.Id)[0]
				});
			}


			return View(usersWithRole);
		}
	}
}