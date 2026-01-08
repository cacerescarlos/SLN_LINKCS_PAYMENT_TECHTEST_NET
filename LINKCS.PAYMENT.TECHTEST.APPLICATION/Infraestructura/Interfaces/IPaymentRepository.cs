using LINKCS.PAYMENT.TECHTEST.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINKCS.PAYMENT.TECHTEST.APPLICATION.Infraestructura.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> AddAsync(Payment payment);
        Task<IEnumerable<Payment>> GetByCustomerIdAsync(string customerId);
    }
}
