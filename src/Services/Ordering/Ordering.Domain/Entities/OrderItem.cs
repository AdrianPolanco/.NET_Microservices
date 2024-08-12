﻿namespace Ordering.Domain.Entities
{
    public class OrderItem : Entity<OrderItemId>
    {
        internal OrderItem(OrderId orderId, ProductId productId, int quantity, decimal price)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public OrderId OrderId { get; set; } = default!;
        public ProductId ProductId { get; set; } = default!;
        public int Quantity { get; set; } = default!;
        public decimal Price { get; set; } = default!;
    }
}
