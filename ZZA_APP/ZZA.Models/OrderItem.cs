using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZZA.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public Guid? StoreId { get; set; }
        public long OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductSizeId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string Instructions { get; set; }
        public List<OrderItemOption> Options { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public ProductSize Size { get; set; }
    }
}
