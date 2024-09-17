using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace EasyCachIdentityProject.Presentation.Controllers
{
	public class ExchangeController : Controller
	{
		public async Task<IActionResult> Index()
		{
            #region USD_TR
            var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=USD&to=TRY&amount=1"),
				Headers =
	{
		{ "x-rapidapi-key", "dae4557595msh1e4c4979d0f8bfbp13e57ejsn6f5eeb23a3d4" },
		{ "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(body);

                // rate değerini al
                var rate = data.info.rate;
                ViewBag.UsdToTry = rate;
			}
            #endregion


            #region EUR_TR
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=EUR&to=TRY&amount=1"),
                Headers =
    {
        { "x-rapidapi-key", "dae4557595msh1e4c4979d0f8bfbp13e57ejsn6f5eeb23a3d4" },
        { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(body2);

                // rate değerini al
                var rate = data.info.rate;
                ViewBag.EurToTry = rate;
            }
            #endregion

            #region GBP_TR
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=GBP&to=TRY&amount=1"),
                Headers =
{
    { "x-rapidapi-key", "dae4557595msh1e4c4979d0f8bfbp13e57ejsn6f5eeb23a3d4" },
    { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
},
            };
            using (var response3 = await client2.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(body3);

                // rate değerini al
                var rate = data.info.rate;
                ViewBag.GbpToTry = rate;
            }
            #endregion

            #region EUR_USD
            var client4 = new HttpClient();
            var request4 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=EUR&to=USD&amount=1"),
                Headers =
    {
        { "x-rapidapi-key", "dae4557595msh1e4c4979d0f8bfbp13e57ejsn6f5eeb23a3d4" },
        { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
            };
            using (var response4 = await client2.SendAsync(request4))
            {
                response4.EnsureSuccessStatusCode();
                var body4 = await response4.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(body4);

                // rate değerini al
                var rate = data.info.rate;
                ViewBag.EurToUsd = rate;
            }
            #endregion


            return View();

		}
	}
}
