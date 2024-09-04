using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidApi.Models;
using Newtonsoft.Json;

namespace MultiShop.RapidApi.Controllers
{
    public class EcommerceController : Controller
    {
        public async Task<IActionResult> ECommerceList()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-product-search.p.rapidapi.com/search?q=logitech%20fare&country=tr&language=en&page=1&limit=10&sort_by=BEST_MATCH&product_condition=ANY&min_rating=ANY"),
                Headers =
            {
                { "x-rapidapi-key", "abedb3b754msh1231493457e791dp16ec12jsndbe4630f6b52" },
                { "x-rapidapi-host", "real-time-product-search.p.rapidapi.com" },
            },
            };

            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {


                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<ECommerceViewModel.Rootobject>(body);
                    var v = model.data.products.ToList();
                    ViewBag.price = string.Join("-", v.FirstOrDefault().typical_price_range);
                    return View(v);
                }
                else
                {
                    List<ECommerceViewModel.Product>? em = new List<ECommerceViewModel.Product>();
                    ECommerceViewModel.Product m = new ECommerceViewModel.Product();
                    m.product_title = "Limit Doldu";
                    
                    em.Add(m);

                    return View(em);
                }
            }

        }
    }
}
