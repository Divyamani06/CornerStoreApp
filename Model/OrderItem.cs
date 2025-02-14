﻿using System.ComponentModel.DataAnnotations;
namespace CornerStore.API.Model
{
    public class OrderItem
    {
        [Key]
        public Guid OrderItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
