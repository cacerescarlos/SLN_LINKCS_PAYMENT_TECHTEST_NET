using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINKCS.PAYMENT.TECHTEST.DOMAIN.Enums
{
    public enum PaymentStatus
    {
        Pendiente = 0,
        Confirmado = 1,
        Rechazado = 2
    }
    public static class PaymentStatusExtensions
    {
        public static string ToStatusString(this PaymentStatus status)
        {
            return status switch
            {
                PaymentStatus.Pendiente => "pendiente",
                PaymentStatus.Confirmado => "confirmado",
                PaymentStatus.Rechazado => "rechazado",
                _ => "desconocido"
            };
        }
    }
}
