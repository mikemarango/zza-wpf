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
    public class OrderRepository
    {
        private readonly ApplicationContext context;

        public OrderRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<List<OrderStatus>> GetOrderStatusesAsync()
        {
            return await context.OrderStatuses.ToListAsync();
        }


        public async Task<List<Order>> GetOrdersAsync()
        {
            return await context.Orders.ToListAsync();
        }

        public async Task<List<Order>> GetOrdersAsync(Guid id)
        {
            return await context.Orders.Where(o => o.CustomerId == id).ToListAsync();
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await context.Orders
                .Include(o => o.OrderItems)
                .Include(c => c.OrderItems.SelectMany(oi => oi.Options))
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order != null)
            {
                foreach (var orderItem in order.OrderItems)
                {
                    foreach (var option in orderItem.Options)
                    {
                        context.OrderItemOptions.Remove(option);
                    }
                    context.OrderItems.Remove(orderItem);
                }
            }

            await context.SaveChangesAsync();

        }
    }
}
