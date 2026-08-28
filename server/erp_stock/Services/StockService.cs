using erp_stock.Databases;
using erp_stock.Interfaces;
using erp_stock.Models;
using Microsoft.EntityFrameworkCore;

namespace erp_stock.Services;

public class StockService(SqliteDBContext context):IStockService
{
    public void Increase(ItemModel item)
    {
        
    }

    public StockModel Decrease(int? id,int amount)
    {
        StockModel? stock = context.Stocks.FirstOrDefault(s=>s.ItemId == id);
        if (stock == null)
        {
            throw new Exception("invalid stock");
        }

        if (stock.Amount >= amount)
        {
            stock.Amount -= amount;
        }
        else
        {
            throw new Exception("invalid stock");
        }
        stock.UpdatedAt = DateTime.UtcNow;
        context.SaveChanges();
        return stock;
    }

    public StockModel? CheckAmount(ItemModel item)
    {
        return context.Stocks.FirstOrDefault(s=>s.ItemId == item.Id);
    }

    public List<StockModel>? GetAll()
    {
        return context.Stocks.Include(s=>s.Item).ToList();
    }
}