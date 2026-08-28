using erp_stock.Models;

namespace erp_stock.Interfaces;

public interface IStockService
{
    public void Increase(ItemModel  item);
    public void Decrease(ItemModel  item);
    public void CheckAmount(ItemModel  item);
}