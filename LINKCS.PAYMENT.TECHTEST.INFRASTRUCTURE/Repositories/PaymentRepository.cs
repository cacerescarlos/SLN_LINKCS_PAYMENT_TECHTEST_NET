using Dapper;
using LINKCS.PAYMENT.TECHTEST.APPLICATION.Infraestructura.Interfaces;
using LINKCS.PAYMENT.TECHTEST.DOMAIN.Entities;
using LINKCS.PAYMENT.TECHTEST.INFRASTRUCTURE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINKCS.PAYMENT.TECHTEST.INFRASTRUCTURE.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DapperContext _context;

        public PaymentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Payment> AddAsync(Payment payment)
        {
            var sql = @"INSERT INTO Payments (PaymentId, CustomerId, ServiceProvider, Amount, Status, CreatedAt) 
                       VALUES (@PaymentId, @CustomerId, @ServiceProvider, @Amount, @Status, @CreatedAt)";

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(sql, payment);
            return payment;
        }

        public async Task<IEnumerable<Payment>> GetByCustomerIdAsync(string customerId)
        {
            var sql = "SELECT * FROM Payments WHERE CustomerId = @CustomerId";

            using var connection = _context.CreateConnection();
            var payments = await connection.QueryAsync<Payment>(sql, new { CustomerId = customerId }) ?? Enumerable.Empty<Payment>();
            return payments.AsEnumerable();
        }
    }
}