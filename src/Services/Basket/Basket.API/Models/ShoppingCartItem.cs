namespace Basket.API.Models;

public class ShoppingCartItem
{
    public Guid ProductId { get; set; } = default!;
    public int Quantity { get; set; } = 0;
    public string Color { get; set; } = null!;
    public decimal Price { get; set; } = default!;
    public string ProductName { get; set; } = default!;
}