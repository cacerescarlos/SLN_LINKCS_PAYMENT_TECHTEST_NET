using LINKCS.PAYMENT.TECHTEST.APPLICATION.Dtos;
using LINKCS.PAYMENT.TECHTEST.APPLICATION.Interfaces;
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
        private readonly IPaymentService _paymentService;

        public PaymentController(ILogger<PaymentController> logger, IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody][Required] RequestPaymentDto Payment)
        {
            // Validar objeto
            // Preparar datos para guardarlos en base de datos
            // Validar errores
            var response = await _paymentService.SavePayment(Payment);
            return await Task.FromResult(Ok(response));
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponsePaymentDto>>> GetById([FromQuery][Required] string customerId)
        {
            // Respuesta: ResponsePaymentDto
            // Validar objeto
            // Buscar por id en base de datos
            // Validar errores            
            var response = await _paymentService.GetByCustomerId(customerId);
            return StatusCode(200, response);
        }
    }
}
