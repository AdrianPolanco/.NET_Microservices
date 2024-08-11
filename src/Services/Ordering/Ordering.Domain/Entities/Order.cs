namespace Ordering.Domain.Entities
{
    public class Order : Aggregate<Guid>
    {
        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public Guid CustomerId { get; set; }
        public string OrderName { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        public Payment Payment { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public decimal TotalPrice
        {
            get => _orderItems.Sum(x => x.Price * x.Quantity);
            private set { }
        }
    }
}
