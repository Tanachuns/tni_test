namespace erp_stock.Models;

public class CartModel
{
    public int Id { get; set; }
    public ICollection<CartTransactionModel>? Carts { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}