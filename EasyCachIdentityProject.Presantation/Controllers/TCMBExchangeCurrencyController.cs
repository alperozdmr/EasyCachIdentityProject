using Business.Helpers;
using EasyCachIdentityProject.BusinessLayer.Abstract;
using EasyCachIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EasyCachIdentityProject.Presentation.Controllers
{
    public class TCMBExchangeCurrencyController : Controller
    {
        private readonly IExchangeRateService _exchangeRateService;

        public TCMBExchangeCurrencyController(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }
        public async Task<IActionResult> addAsync() {
            var rates = await XMLReader.GetExchanges();
            foreach(var rate in rates)
            {
                _exchangeRateService.TInsert(rate);
            }
            return RedirectToAction("Index", "TCMBExchangeCurrency");
        }
        public async Task<IActionResult> Index()
        {
            var result = _exchangeRateService.TGetAll();
            if (result.Count == 0) {
               await  addAsync();
            }
            return View(result);
        }
        public async Task<IActionResult> Update()
        {
            var rates = await XMLReader.GetExchanges();
            foreach (var rate in rates)
            {
                var result = _exchangeRateService.TGetAll().Find(x => x.Isim == rate.Isim);
                var tempResult = new ExchangeRate
                {
                    Id = result.Id,
                    BanknoteBuying = rate.BanknoteBuying,
                    BanknoteSelling = rate.BanknoteSelling,
                    CurrencyCode = rate.CurrencyCode,
                    CurrencyName = rate.CurrencyName,
                    ForexBuying = rate.ForexBuying,
                    ForexSelling = rate.ForexSelling,
                    Isim = rate.Isim,
                    Unit = rate.Unit,
                };
                _exchangeRateService.TUpdate(tempResult);
            }
            return RedirectToAction("Index", "TCMBExchangeCurrency");
        }
    }
}
