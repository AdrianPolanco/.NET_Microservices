namespace Basket.API.Models
{
    //Default constructor required for mapping
    public class ShoppingCart()
    {
        public ShoppingCart(string userName): this()
        {
            this.Username = userName;
        }
        public string Username { get; set; } = default!;
        public List<ShoppingCartItem> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

    }
}
