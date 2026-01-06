using LINKCS.PAYMENT.TECHTEST.APPLICATION.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LINKCS.PAYMENT.TECHTEST.PRESENTATION.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PaymentController> _logger;

        public PaymentController(ILogger<PaymentController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody][Required] RequestPaymentDto Payment)
        {
            // Validar objeto
            // Preparar datos para guardarlos en base de datos
            // Validar errores
            return await Task.FromResult(Ok(Payment));
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] string customerId)
        {
            // Respuesta: ResponsePaymentDto
            // Validar objeto
            // Buscar por id en base de datos
            // Validar errores
            var response = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            return await Task.FromResult(Ok(response));
        }
    }
}
