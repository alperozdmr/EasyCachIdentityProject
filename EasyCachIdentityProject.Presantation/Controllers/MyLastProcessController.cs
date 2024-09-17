using EasyCachIdentityProject.BusinessLayer.Abstract;
using EasyCachIdentityProject.DataAccessLayer.Concrete;
using EasyCachIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCachIdentityProject.Presentation.Controllers
{
    public class MyLastProcessController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public MyLastProcessController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var context = new Context();
            int Id = context.CustomerAccounts.Where(x=>x.AppUserId == user.Id && x.CustomerAccountCurrrency == "Türk Lirası").Select(y=>y.CustomerAccountId).FirstOrDefault();
            var values = _customerAccountProcessService.TMyLastProcess(Id);
            return View(values);
        }
    }
}
