using erp_stock.Databases;
using erp_stock.Interfaces;
using erp_stock.Models;

namespace erp_stock.Services;

public class CartService(SqliteDBContext context):ICartService
{

    public void Add(int id, ItemModel item, int amount)
    {
        throw new NotImplementedException();
    }

    public void Remove(int id, ItemModel item, int amount)
    {
        throw new NotImplementedException();
    }

    public CartModel? Get(int id)
    {
        return context.Carts.FirstOrDefault(c => c.Id == id);
    }
}