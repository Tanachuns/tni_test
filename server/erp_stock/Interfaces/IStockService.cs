using erp_stock.Models;

namespace erp_stock.Interfaces;

public interface IStockService
{
    public void Increase(ItemModel item);
    public StockModel Decrease(int?  id,int amount);
    public StockModel? CheckAmount(ItemModel  item);
    public List<StockModel>? GetAll();
    public StockModel? Get(int id);
    
}