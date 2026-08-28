using erp_stock.Databases;
using erp_stock.Interfaces;
using erp_stock.Models;
using Microsoft.EntityFrameworkCore;

namespace erp_stock.Services;

public class CartService(SqliteDBContext context,IStockService stockService):ICartService
{
    public CartModel Create()
    {
        CartModel cart = new CartModel();
        cart.Carts = new List<CartTransactionModel>();
        context.Carts.Add(cart);
        context.SaveChanges();
        return Get(cart.Id);
    }

    public CartModel Add(int id, ItemModel item, int amount)
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
        return cart;
    }

    public CartModel Remove(int id, ItemModel item, int amount)
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
        return cart;
    }

    public CartModel Clear(int id)
    {
        CartModel cart = context.Carts.FirstOrDefault(c => c.Id == id);
        foreach (var cartTransactionModel in cart.Carts)
        {
            context.CartTransactions.Remove(cartTransactionModel);
        }
        cart.Carts = new List<CartTransactionModel>();
        cart.UpdatedAt =  DateTime.UtcNow;
        context.SaveChanges();
        return cart;
    }

    public CartModel Checkout(int id)
    {
        CartModel cart = context.Carts.Include(cartModel => cartModel.Carts).ThenInclude(i=>i.Item).FirstOrDefault(c => c.Id == id);
        foreach (var cartTransactionModel in cart.Carts)
        {
            
            stockService.Decrease(cartTransactionModel.ItemId, cartTransactionModel.Amount);
        }
        cart.IsCheckedOut = true;
        cart.UpdatedAt =  DateTime.UtcNow;
        context.SaveChanges();
        return cart;
    }

  
    
    public CartModel? Get(int id)
    {
        return context.Carts.Include(cartModel => cartModel.Carts).ThenInclude(c=>c.Item).FirstOrDefault(c => c.Id == id);
    }
}