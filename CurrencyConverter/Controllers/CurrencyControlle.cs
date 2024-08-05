using CurrencyConverter.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CurrencyConverter.Controllers
{
    public class CurrencyController : Controller
    {
        private static readonly List<string> Images = new List<string>
            {
                "\\img\\An.jpg",
                "\\img\\AnP.jpg",
                "\\img\\AnS.jpg",
                "\\img\\El.jpg",
                "\\img\\Sas.jpg",
                "\\img\\Ser.jpg",
                "\\img\\K.jpg",
                "\\img\\AnK.jpg",
                "\\img\\Ser2.jpg"
            };

        private string GetRandomImage()
        {
            var random = new Random();
            int index = random.Next(Images.Count);
            return Images[index];
        }
       
        public IActionResult Index()
        {
            ViewData["Title"] = "Currency Converter";

            var currencies = CurrencyData.GetCurrencies();
            ViewBag.RandomImage = GetRandomImage();
            return View(currencies);
        }

        [HttpPost]
        public IActionResult Convert(string fromCurrency, string toCurrency, double amount)
        {
            ViewData["Title"] = "Currency Converter";

            var currencies = CurrencyData.GetCurrencies();

            ViewBag.RandomImage = GetRandomImage();

            var from = currencies.FirstOrDefault(c => c.Code == fromCurrency);
            var to = currencies.FirstOrDefault(c => c.Code == toCurrency);

            if (from == null || to == null)
            {
                return BadRequest("Invalid currency code.");
            }

            var convertedAmount = (amount / from.Rate) * to.Rate;
            var roundedAmount = Math.Round(convertedAmount, 2);

            string result = $"{amount} {fromCurrency} = {roundedAmount:F2} {toCurrency}";


            ViewBag.Result = result;
            ViewBag.FromCurrency = fromCurrency;
            ViewBag.ToCurrency = toCurrency;
            ViewBag.Amount = amount;
            return View("Index", currencies);
        }
    }
}
