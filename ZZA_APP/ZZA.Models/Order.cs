using System;
using System.Collections.Generic;
using System.Text;

namespace ZZA.Models
{
    public class Order
    {
        public long Id { get; set; }
        public Guid? StoreId { get; set; }
        public Guid CustomerId { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal DeliveryCharge { get; set; }
        public decimal ItemsTotal { get; set; }
        public string Phone { get; set; }
        public string DeliveryStreet { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryState { get; set; }
        public string DeliveryZip { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public OrderStatus Status { get; set; }
    }
}
