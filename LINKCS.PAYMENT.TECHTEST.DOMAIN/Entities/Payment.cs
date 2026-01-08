using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINKCS.PAYMENT.TECHTEST.DOMAIN.Entities
{
    public class Payment
    {
        public string PaymentId { get; set; } = string.Empty;
        public string CustomerId { get; set; } = string.Empty;
        public string ServiceProvider { get; set; } = string.Empty;
        public decimal Amount { get; set; } = 0;
        public string Status { get; set; } = "pendiente";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
