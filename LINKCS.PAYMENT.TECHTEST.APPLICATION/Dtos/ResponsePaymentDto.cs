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

        /// <summary>
        /// EXT-FR-FE-158 Delivery date at value line
        /// G1.09 All Date fields are in the following format: AAAA-MM-DD in UBL AAAAMMJJ in CII In the context of e-reporting and the directory, the format of date fields must be: AAAAMMJJ. Conversion from UBL to CII. Specifically in flow 10 (either direct or converted), the format is a date without dashes.
        /// G1.36 In a date, the year must not be < 2000 and > 2099.
        /// G6.12 This data is mandatory from 01/09/2027 when the data must be mentioned on the invoice in accordance with the regulations (CGI, Ccom,...).Business rule but cannot be controlled from an application point of view.
        /// </summary>
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
