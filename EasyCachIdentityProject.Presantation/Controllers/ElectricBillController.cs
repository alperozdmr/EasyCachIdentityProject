using Microsoft.AspNetCore.Mvc;

namespace EasyCachIdentityProject.Presentation.Controllers
{
	public class ElectricBillController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
