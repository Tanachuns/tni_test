namespace erp_stock.Models;

public class CartTransactionModel
{
    public int Id { get; set; }
    public int? ItemId { get; set; }
    public ItemModel? Item { get; set; }
    public int Amount { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}