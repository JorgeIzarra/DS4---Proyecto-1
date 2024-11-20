using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using CalculadoraWeb.Models;
using Newtonsoft.Json;
using System.Text;

namespace CalculadoraWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly string apiUrl = "https://localhost:44334/api/Calculos";
        private readonly HttpClient _httpClient;

        public HomeController()
        {
            _httpClient = new HttpClient();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Calcular(double numero1, double numero2, string operacion)
        {
            try
            {
                var calculo = new Calculo
                {
                    Numero1 = numero1,
                    Numero2 = numero2,
                    Operacion = operacion
                };

                var json = JsonConvert.SerializeObject(calculo);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var resultado = await response.Content.ReadAsStringAsync();
                    return Json(resultado);
                }

                return Json(new { error = "Error al realizar el cálculo" });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
    }
}