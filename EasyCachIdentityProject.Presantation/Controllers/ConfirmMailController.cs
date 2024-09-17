using EasyCachIdentityProject.EntityLayer.Concrete;
using EasyCachIdentityProject.Presentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCachIdentityProject.Presentation.Controllers
{
	public class ConfirmMailController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public ConfirmMailController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var value = TempData["Mail"];
			ViewBag.v=value;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
		{
			var user = await _userManager.FindByEmailAsync(confirmMailViewModel.Mail);
			user.EmailConfirmed = true;
			await _userManager.UpdateAsync(user);
			if (user.ConfirmCode == confirmMailViewModel.ConfirmCode)
			{
				return RedirectToAction("Index","Login");
			}
			return View();
		}
	}
}
