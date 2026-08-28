namespace erp_stock.Models.http;

public class CartRequestModel
{
    public int CartId { get; set; }
    public int ItemId { get; set; }
    public int Amount { get; set; }
}