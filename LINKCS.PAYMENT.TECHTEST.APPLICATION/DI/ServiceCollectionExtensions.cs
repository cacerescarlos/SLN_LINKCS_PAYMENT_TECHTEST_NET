using LINKCS.PAYMENT.TECHTEST.APPLICATION.Interfaces;
using LINKCS.PAYMENT.TECHTEST.APPLICATION.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINKCS.PAYMENT.TECHTEST.APPLICATION.DI
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registra los servicios
        /// </summary>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();
            return services;
        }
    }
}
