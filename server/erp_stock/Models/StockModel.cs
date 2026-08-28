namespace erp_stock.Models;

public class StockModel
{
    public int Id { get; set; }
    public int? ItemId { get; set; }
    public ItemModel? Item  { get; set; }
    public int Amount { get; set; } = 0;
}