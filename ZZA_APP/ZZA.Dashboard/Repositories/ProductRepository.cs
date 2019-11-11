using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZZA.Dashboard.Data;
using ZZA.Models;

namespace ZZA.Dashboard.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationContext context;

        public ProductRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return context.Products.ToListAsync();
        }

        public Task<List<ProductOption>> GetProductOptionsAsync()
        {
            return context.ProductOptions.ToListAsync();
        }

        public Task<List<ProductSize>> GetProductSizesAsync()
        {
            return context.ProductSizes.ToListAsync();
        }

    }
}
