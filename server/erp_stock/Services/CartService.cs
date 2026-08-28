using erp_stock.Databases;
using erp_stock.Interfaces;
using erp_stock.Models;
using Microsoft.EntityFrameworkCore;

namespace erp_stock.Services;

public class CartService(SqliteDBContext context):ICartService
{
    public CartModel Create()
    {
        CartModel cart = new CartModel();
        cart.Carts = new List<CartTransactionModel>();
        context.Carts.Add(cart);
        context.SaveChanges();
        return Get(cart.Id);
    }

    public void Add(int id, ItemModel item, int amount)
    {
        CartModel cart = context.Carts.Include(cartModel => cartModel.Carts).FirstOrDefault(c => c.Id == id);
        CartTransactionModel  cartTransactionModel = cart.Carts.FirstOrDefault(t => t.Item == item) ;
        if (cartTransactionModel== null)
        {
            cartTransactionModel = new CartTransactionModel
            {
                Item = item,
                Amount = amount
            };
            cart.Carts.Add(cartTransactionModel);
        }
        else
        {
            cartTransactionModel.Amount += amount;
        }
        cart.UpdatedAt =  DateTime.UtcNow;
        context.SaveChanges();
    }

    public void Remove(int id, ItemModel item, int amount)
    {
        CartModel cart = context.Carts.Include(cartModel => cartModel.Carts).FirstOrDefault(c => c.Id == id);
        CartTransactionModel  cartTransactionModel = cart.Carts.FirstOrDefault(t => t.Item == item) ;
        if (cartTransactionModel== null)
        {
           throw new Exception("Cart not found");
        }

        if (cartTransactionModel.Amount > amount)
        {
            cartTransactionModel.Amount -= amount;
            
        }
        else
        {
            cart.Carts.Remove(cartTransactionModel);
            context.CartTransactions.Remove(cartTransactionModel);
        }
        cart.UpdatedAt =  DateTime.UtcNow;
        context.SaveChanges();
    }

    public CartModel? Get(int id)
    {
        return context.Carts.Include(cartModel => cartModel.Carts).FirstOrDefault(c => c.Id == id);
    }
}