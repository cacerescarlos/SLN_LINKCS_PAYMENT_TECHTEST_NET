using LINKCS.PAYMENT.TECHTEST.APPLICATION.Dtos;
using LINKCS.PAYMENT.TECHTEST.APPLICATION.Infraestructura.Interfaces;
using LINKCS.PAYMENT.TECHTEST.APPLICATION.Interfaces;
using LINKCS.PAYMENT.TECHTEST.DOMAIN.Entities;
using LINKCS.PAYMENT.TECHTEST.DOMAIN.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINKCS.PAYMENT.TECHTEST.APPLICATION.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }


        public async Task<IEnumerable<ResponsePaymentDto>> GetByCustomerId(string customerId)
        {
            try
            {
                var payments = await _paymentRepository.GetByCustomerIdAsync(customerId);
                
                #region Mapeo a DTO
                var response = payments.Select(payment => new ResponsePaymentDto
                {
                    PaymentId = payment.PaymentId,
                    ServiceProvider = payment.ServiceProvider,
                    Amount = payment.Amount,
                    Status = payment.Status,
                    CreatedAt = payment.CreatedAt
                }).AsEnumerable();
                #endregion

                return response;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<string> SavePayment(RequestPaymentDto paymentDto)
        {
            try
            {
                #region Logica de negocio
                // 1. Estado inicial pendiente
                var status = PaymentStatus.Pendiente;

                // 2. Rechazar montos negativos
                if (paymentDto.Amount < 0)
                {
                    status = PaymentStatus.Rechazado;
                    return "Pago rechazado: monto debe ser mayor que cero.";
                }

                // 3. Rechazar montos > 1500 BS
                if (paymentDto.Amount > 1500)
                {
                    status = PaymentStatus.Rechazado;
                    return "Pago rechazado: monto excede el límite de 1500 BS.";
                }
                #endregion

                #region Guardar en base de datos
                var payment = new Payment
                {
                    PaymentId = Guid.NewGuid().ToString(),
                    CustomerId = paymentDto.CustomerId,
                    ServiceProvider = paymentDto.ServiceProvider,
                    Amount = paymentDto.Amount,
                    Status = PaymentStatusExtensions.ToStatusString(status),
                    CreatedAt = DateTime.UtcNow
                };
                var savedPayment = await _paymentRepository.AddAsync(payment);
                #endregion

                return $"Pago guardado con éxito. ID de Pago: {savedPayment.PaymentId}";
            }
            catch (Exception e)
            {
                return $"Error desconocido: {e.Message}";
            }
        }
    }
}
