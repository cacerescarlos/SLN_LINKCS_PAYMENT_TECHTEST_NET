using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINKCS.PAYMENT.TECHTEST.APPLICATION.Dtos
{
    public class ResponseErrorDto
    {
        public string ErrorCode { get; set; } = default!;
        public string? ErrorMessage { get; set; }
    }
}
