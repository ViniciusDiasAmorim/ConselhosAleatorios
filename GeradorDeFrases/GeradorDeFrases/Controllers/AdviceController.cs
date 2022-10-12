using GeradorDeFrases.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GeradorDeFrases.Controllers
{
    public class AdviceController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> GenerateAdvice()
        {

            string url = "https://api.adviceslip.com/advice";

            HttpClient cliente = new HttpClient { BaseAddress = new Uri(url) };

            var response = await cliente.GetAsync("advice");

            var content = await response.Content.ReadAsStringAsync();

            var advice = JsonConvert.DeserializeObject<Advice>(content);

            return View(advice);
        }
        public async Task<IActionResult> SearchAdvice(string query)
        {
            try
            {
                if (!string.IsNullOrEmpty(query))
                {
                    string url = $"https://api.adviceslip.com/advice/search/{query}";

                    HttpClient cliente = new HttpClient { BaseAddress = new Uri(url) };

                    var response = await cliente.GetAsync(query);

                    var content = await response.Content.ReadAsStringAsync();

                    var advice = JsonConvert.DeserializeObject<AdviceByQuery>(content);

                    if (advice.Slips != null)
                    {
                        Console.WriteLine(advice.Slips);
                        return View(advice);
                    }
                }
                else
                {
                    return RedirectToAction("GenerateAdvice", "Advice");

                }

                return View("~/Views/Advice/AdviceError.cshtml");

            }
            catch
            {             
                return View("~/Views/Advice/AdviceError.cshtml");
            }
        }

    }
}
