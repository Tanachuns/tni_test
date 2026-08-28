using erp_stock.Models;

namespace erp_stock.Interfaces;

public interface ICartService
{
    public void Add(int id,ItemModel  item, int amount);
    public void Remove(int id,ItemModel  item, int amount);
    public CartModel? Get(int id);
}