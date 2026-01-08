using LINKCS.PAYMENT.TECHTEST.APPLICATION.Infraestructura.Interfaces;
using LINKCS.PAYMENT.TECHTEST.INFRASTRUCTURE.Data;
using LINKCS.PAYMENT.TECHTEST.INFRASTRUCTURE.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINKCS.PAYMENT.TECHTEST.INFRASTRUCTURE.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Registrar contexto de base de datos
            services.AddSingleton<DapperContext>();

            // Registrar repositorios
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            return services;
        }
    }
}
