using erp_stock.Models;

namespace erp_stock.Interfaces;

public interface ICartService
{
    public void Add(ItemModel  item, int amount);
    public void Remove(ItemModel  item, int amount);
    public List<ItemModel> Get();
}