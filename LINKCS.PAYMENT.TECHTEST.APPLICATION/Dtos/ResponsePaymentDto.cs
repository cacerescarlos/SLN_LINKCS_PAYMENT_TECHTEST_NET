using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LINKCS.PAYMENT.TECHTEST.APPLICATION.Dtos
{
    public class ResponsePaymentDto
    {
        [JsonPropertyName("paymentId")]
        public string? PaymentId { get; set; }

        [JsonPropertyName("serviceProvider")]
        public string? ServiceProvider { get; set; }

        [JsonPropertyName("amount")]
        public decimal? Amount { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

    }
}
