using EasyCachIdentityProject.BusinessLayer.Abstract;
using EasyCachIdentityProject.DataAccessLayer.Concrete;
using EasyCachIdentityProject.DtoLayer.Dtos.CustomerAccountProcessDtos;
using EasyCachIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCachIdentityProject.Presentation.Controllers
{

    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index(string mycurrency)
        {
            ViewBag.currency = mycurrency;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto)
        {
            var context = new Context();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberId = context.CustomerAccounts.Where(x => x.CustomerAccountNumber == sendMoneyForCustomerAccountProcessDto.ReceiverAccountNumber).Select(y => y.CustomerAccountId).FirstOrDefault();

            var senderAccountNumberId = context.CustomerAccounts.Where(x => x.AppUserId == user.Id).Where(y => y.CustomerAccountCurrrency == "Türk Lirası").Select(z => z.CustomerAccountId).FirstOrDefault(); 

            var values = new CustomerAccountProcess();
            values.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            values.SenderID = senderAccountNumberId;
            values.ProcessType = "Havale";
            values.ReceiverID = receiverAccountNumberId;
            values.Amount= sendMoneyForCustomerAccountProcessDto.Amount;
            values.Description = sendMoneyForCustomerAccountProcessDto.Description;

            _customerAccountProcessService.TInsert(values);
            //_customerAccountProcessService.TInsert();

            return RedirectToAction("Index","Deneme");
        }
    }
}
