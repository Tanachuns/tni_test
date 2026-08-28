using erp_stock.Models;

namespace erp_stock.Interfaces;

public interface ICartService
{
    public CartModel Create();
    public CartModel Add(int id,ItemModel  item, int amount);
    public CartModel Remove(int id,ItemModel  item, int amount);
    public CartModel Clear(int id);
    public CartModel Checkout(int id);
    public CartModel? Get(int id);
}