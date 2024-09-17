using Microsoft.AspNetCore.Mvc;

namespace EasyCachIdentityProject.Presentation.Controllers
{
	public class CustomerLayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
