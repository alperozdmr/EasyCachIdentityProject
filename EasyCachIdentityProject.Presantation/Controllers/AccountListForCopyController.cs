using EasyCachIdentityProject.BusinessLayer.Abstract;
using EasyCachIdentityProject.DataAccessLayer.Concrete;
using EasyCachIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCachIdentityProject.Presentation.Controllers
{
    public class AccountListForCopyController : Controller
    {
        public readonly UserManager<AppUser> _userManager;
        public readonly ICustomerAccountService _customerAccountService;

        public AccountListForCopyController(UserManager<AppUser> userManager, ICustomerAccountService customerAccountService)
        {
            _userManager = userManager;
            _customerAccountService = customerAccountService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //var context = new Context();
            //int Id = context.CustomerAccounts.Where(x => x.AppUserId == user.Id && x.CustomerAccountCurrrency == "Türk Lirası").Select(y => y.CustomerAccountId).FirstOrDefault();
            var values = _customerAccountService.TGetCustomerAccountsList(user.Id);

            return View(values);
        }
    }
}
