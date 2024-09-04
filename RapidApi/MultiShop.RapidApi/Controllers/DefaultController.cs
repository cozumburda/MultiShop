using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidApi.Models;
using Newtonsoft.Json;
using System.Reflection;

namespace MultiShop.RapidApi.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<IActionResult> WheatherDetail()
        {
            //WeatherViewModel? model = new WeatherViewModel();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://the-weather-api.p.rapidapi.com/api/weather/ankara"),
                Headers =
                {
                    { "x-rapidapi-key", "abedb3b754msh1231493457e791dp16ec12jsndbe4630f6b52" },
                    { "x-rapidapi-host", "the-weather-api.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<WeatherViewModel.Rootobject>(body);
                return View(model);
            }
            //return View();
        }

        public async Task<IActionResult> Exchange()
        {
            ExchangeRateViewModel model = new ExchangeRateViewModel();
            var client = new HttpClient();
            var client2 = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&language=TR&to_symbol=TRY"),
                Headers =
                {
                    { "x-rapidapi-key", "abedb3b754msh1231493457e791dp16ec12jsndbe4630f6b52" },
                    { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
                },
            };
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=EUR&language=TR&to_symbol=TRY"),
                Headers =
                {
                    { "x-rapidapi-key", "abedb3b754msh1231493457e791dp16ec12jsndbe4630f6b52" },
                    { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var usd = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body);
                model.Usd = decimal.Parse(usd.data.exchange_rate.ToString());
                model.UsdSymbol = usd.data.to_symbol;
            }
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                var eur = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body2);
                model.Eur = decimal.Parse(eur.data.exchange_rate.ToString());
                model.EurSymbol= eur.data.to_symbol;
            }

            return View(model);
        }
    }
}
