using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LINKCS.PAYMENT.TECHTEST.APPLICATION.Dtos
{
    public class RequestPaymentDto
    {
        /// <summary>
        /// EXT-FR-FE-158-0
        /// G6.12 This data is mandatory from 01/09/2027 when the data must be mentioned on the invoice in accordance with the regulations (CGI, Ccom,...).Business rule but cannot be controlled from an application point of view.
        /// </summary>
        [JsonPropertyName("customerId")]
        [Required]
        public string? CustomerId { get; set; }

        /// <summary>
        /// EXT-FR-FE-158 Delivery date at value line
        /// G1.09 All Date fields are in the following format: AAAA-MM-DD in UBL AAAAMMJJ in CII In the context of e-reporting and the directory, the format of date fields must be: AAAAMMJJ. Conversion from UBL to CII. Specifically in flow 10 (either direct or converted), the format is a date without dashes.
        /// G1.36 In a date, the year must not be < 2000 and > 2099.
        /// G6.12 This data is mandatory from 01/09/2027 when the data must be mentioned on the invoice in accordance with the regulations (CGI, Ccom,...).Business rule but cannot be controlled from an application point of view.
        /// </summary>
        [JsonPropertyName("serviceProvider")]
        [Required]
        public string? ServiceProvider { get; set; }

        /// <summary>
        /// EXT-FR-FE-158-1
        /// In CII, it is necessary to integrate the code "102" in order to reference a date in the format YYYYMMDD in the tags EXT-FR-FE-158-0 and EXT-FR-FE-158-1.
        /// G6.12 This data is mandatory from 01/09/2027 when the data must be mentioned on the invoice in accordance with the regulations (CGI, Ccom,...).Business rule but cannot be controlled from an application point of view.
        /// </summary>
        [JsonPropertyName("amount")]
        [Required]
        public decimal? Amount { get; set; }
    }
}
