using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZA.Dashboard.Data;
using ZZA.Models;

namespace ZZA.Dashboard.Repositories
{
    public class CustomerRepository
    {
        private readonly ApplicationContext context;

        public CustomerRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            return context.Customers.AsNoTracking().ToListAsync();
        }

        public Task<Customer> GetCustomerAsync(Guid id)
        {
            return context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            if (!context.Customers.Local.Any(c => c.Id == customer.Id))
            {
                context.Customers.Attach(customer);
            }
            context.Entry(customer).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            var customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer != null)
            {
                context.Customers.Remove(customer);
            }
            await context.SaveChangesAsync();
        }
    }
}
