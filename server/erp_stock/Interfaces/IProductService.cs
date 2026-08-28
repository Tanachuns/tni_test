using erp_stock.Models;

namespace erp_stock.Interfaces;

public interface IProductService
{
    public List<ItemModel> All();
    public ItemModel? Find();
}