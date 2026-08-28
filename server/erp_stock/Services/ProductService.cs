using erp_stock.Databases;
using erp_stock.Interfaces;
using erp_stock.Models;

namespace erp_stock.Services;

public class ProductService(SqliteDBContext context):IProductService
{
    public List<ItemModel> All()
    {
        return context.Items.ToList();
    }

    public ItemModel? Find()
    {
        throw new NotImplementedException();
    }
}