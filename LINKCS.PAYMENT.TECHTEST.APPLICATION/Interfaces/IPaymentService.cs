using LINKCS.PAYMENT.TECHTEST.APPLICATION.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINKCS.PAYMENT.TECHTEST.APPLICATION.Interfaces
{
    public interface IPaymentService
    {
        Task<string> SavePayment(RequestPaymentDto paymentDto);
        Task<List<ResponsePaymentDto>> GetByCustomerId(string customerId);
    }
}
