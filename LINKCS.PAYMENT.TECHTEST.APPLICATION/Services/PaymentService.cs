using LINKCS.PAYMENT.TECHTEST.APPLICATION.Dtos;
using LINKCS.PAYMENT.TECHTEST.APPLICATION.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINKCS.PAYMENT.TECHTEST.APPLICATION.Services
{
    public class PaymentService : IPaymentService
    {
        List<ResponsePaymentDto> paymentsCustomerId = new List<ResponsePaymentDto>()
        {
          new ResponsePaymentDto
                {
                    PaymentId = "PAY-001",
                    ServiceProvider = "Visa",
                    Amount = 150.50m,
                    //Status = 1, // Supongamos 1 = Completado
                    CreatedAt = DateTime.Now.AddDays(-2)
                },
                new ResponsePaymentDto
                {
                    PaymentId = "PAY-002",
                    ServiceProvider = "Mastercard",
                    Amount = 45.00m,
                    //Status = 1,
                    CreatedAt = DateTime.Now.AddDays(-1)
                },
                new ResponsePaymentDto
                {
                    PaymentId = "PAY-003",
                    ServiceProvider = "PayPal",
                    Amount = 1200.00m,
                    //Status = 0, // Supongamos 0 = Pendiente/Error
                    CreatedAt = DateTime.Now
                },
                new ResponsePaymentDto
                {
                    PaymentId = "PAY-004",
                    ServiceProvider = "Stripe",
                    Amount = 89.99m,
                    //Status = 1,
                    CreatedAt = DateTime.Now.AddHours(-5)
                },
                new ResponsePaymentDto
                {
                    PaymentId = "PAY-005",
                    ServiceProvider = "Visa",
                    Amount = 500.00m,
                    //Status = 2, // Supongamos 2 = Reembolsado
                    CreatedAt = DateTime.Now.AddMonths(-1)
                }

        };

        public async Task<List<ResponsePaymentDto>> GetByCustomerId(string customerId)
        {
            // TODO: Logica de negocio
            // Consultar en base de datos - Repositorio , filtrando el id del cliente
            // Devuelve una lista de pagos por customerId <-cliente            
            return await Task.FromResult(paymentsCustomerId);
        }

        public async Task<string> SavePayment(RequestPaymentDto paymentDto)
        {
            // TODO: Logica de negocio
            // Estado en pendiente
            // Rechazar montos > 15000 BS
            // Rechazar montos en dólares
            // Guardar en base de datos Repositorio
            paymentsCustomerId.Add(
                  new ResponsePaymentDto
                  {
                      PaymentId = "PAY-NUEVO",
                      ServiceProvider = "Visax",
                      Amount = 500,
                      //Status = 2, // Supongamos 2 = Reembolsado
                      CreatedAt = DateTime.Now.AddMonths(-1)
                  }
                );
            return await Task.FromResult("Recibido con éxito");
        }
    }
}
