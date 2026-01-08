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
        ///
        /// </summary>
        [JsonPropertyName("customerId")]
        [Required]
        public required string CustomerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("serviceProvider")]
        [Required]
        public required string ServiceProvider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("amount")]
        [Required]
        public required decimal Amount { get; set; }
    }
}
