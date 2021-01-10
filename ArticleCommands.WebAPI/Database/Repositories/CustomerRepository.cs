using ArticleCommands.WebAPI.Database.Contracts;
using DomainUsage.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleCommands.WebAPI.Database.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FrontierContext _ctxt;
        private readonly Serilog.ILogger _logr;

        public CustomerRepository(FrontierContext ctxt, Serilog.ILogger logr)
        {
            _ctxt = ctxt;
            _logr = logr;
        }

        public async Task<Customer> GetByIdAsync(int Id)
        {
            var CustomerSku = await _ctxt.Customers.FirstOrDefaultAsync(y => y.CustomerId == Id);
            _logr.Information("The following customer has been retrieved {@Customer}", CustomerSku);
            return CustomerSku;
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            _ctxt.Set<Customer>().Add(customer);
            customer.DateCreated = DateTime.UtcNow;
            customer.CreatedBy = customer?.CreatedBy ?? "System Ingestion";
            await _ctxt.SaveChangesAsync();
            _logr.Information("The following customer has been added {@Customer}", customer);
            return customer;
        }

        public async Task DeleteAsync(Customer customer)
        {
            Task<Customer> customerSku = _ctxt.Customers.FirstOrDefaultAsync(y => y.CustomerId == customer.CustomerId);

            if (customerSku != null)
            {
                var theId = customerSku.Id;
                _ctxt.Set<Customer>().Remove(customer);
                _logr.Information("The following customer will be removed {@Customer}", customer);
            }

            await _ctxt.SaveChangesAsync();
            _logr.Information("The following customer has been removed {@Customer}", customer);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            List<Customer> customerSkus = await _ctxt.Customers.ToListAsync();
            _logr.Information("The following customers have been retrieved {@List<Customer>}", customerSkus);
            return customerSkus;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            Task<Customer> customerSku = _ctxt.Customers.FirstOrDefaultAsync(y => y.CustomerId == customer.CustomerId);
            if (customerSku != null)
            {
                customer.DateModified = DateTime.UtcNow;
                customer.ModifiedBy = customer?.ModifiedBy ?? "System Update";
                await _ctxt.SaveChangesAsync();
                _logr.Information("The following customer has been updated {@Customer}", customer);
            }
            return customer;
        }

        public Customer GetById(int Id)
        {
            var CustomerSku = _ctxt.Customers.FirstOrDefault(y => y.CustomerId == Id);
            return CustomerSku;
        }
    }
}