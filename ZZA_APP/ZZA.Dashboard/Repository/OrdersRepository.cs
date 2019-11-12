using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ZZA.Dashboard.Data;
using ZZA.Models;

namespace ZZA.Dashboard.Repository
{
    public class OrdersRepository
    {
        readonly ZzaDbContext _context = new ZzaDbContext();
        public Task<List<Order>> GetOrdersForCustomersAsync(Guid id)
        {
            return _context.Orders.Where(o => o.CustomerId == id).ToListAsync();
        }

        public Task<List<Order>> GetOrdersAsync()
        {
            return _context.Orders.ToListAsync();
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            if (!_context.Orders.Local.Any(o => o.Id == order.Id))
            {
                _context.Orders.Attach(order);
            }
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrderAsync(int id)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var order = _context.Orders
                    .Include(o => o.OrderItems)
                    .Include(o => o.OrderItems
                    .SelectMany(oi => oi.Options))
                    .FirstOrDefault(o => o.Id == id);

                if (order != null)
                {
                    foreach (var orderItem in order.OrderItems)
                    {
                        foreach (var orderItemOption in orderItem.Options)
                        {
                            _context.OrderItemOptions.Remove(orderItemOption);
                        }
                        _context.OrderItems.Remove(orderItem);
                    }
                    _context.Orders.Remove(order);
                }
                await _context.SaveChangesAsync();
                scope.Complete();
            }
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return _context.Products.ToListAsync();
        }

        public Task<List<ProductOption>> GetProductOptionsAsync()
        {
            return _context.ProductOptions.ToListAsync();
        }

        public Task<List<ProductSize>> GetProductSizesAsync()
        {
            return _context.ProductSizes.ToListAsync();
        }

        public Task<List<OrderStatus>> GetOrderStatusesAsync()
        {
            return _context.OrderStatuses.ToListAsync();
        }

    }
}
