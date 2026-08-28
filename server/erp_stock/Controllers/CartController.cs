using System.Runtime.InteropServices.JavaScript;
using erp_stock.Interfaces;
using erp_stock.Models;
using erp_stock.Models.http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace erp_stock.Controllers;

[Route("api/[controller]")]
public class CartController(IConfiguration config,ICartService cartService,IProductService productService,IStockService stockService) : Controller
{
    [HttpGet("{id}")]
    public IActionResult GetAll(int id)
    {
        try
        {
            CartModel? cart = cartService.Get(id);
            if (cart == null)
            {
                return BadRequest("invalid cart");
            }
            return Ok(cart);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500,ex.Message);
        }
    }

    [HttpPatch]
    [Route("/api/cart/increase")]
    public IActionResult Add([FromBody] CartRequestModel request)
    {
        try
        {
            ItemModel? item = productService.FindbyId(request.ItemId);
            
            if (item == null || request.Amount <= 0  )
            {
                return BadRequest("invalid item");
            }
            
            StockModel? stock = stockService.CheckAmount(item);
            if (stock == null || stock.Amount <= 0)
            {
                return BadRequest("invalid stock");
            }

            CartModel cart = cartService.Get(request.CartId) ?? cartService.Create();
            if (cart == null ||  cart.IsCheckedOut)
            {
                cart = cartService.Create();
            }
            cartService.Add(cart.Id,item, request.Amount);
            return Ok(cart);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500,ex.Message);
        }
    }
    [HttpPatch]
    [Route("/api/cart/decrease")]
    public IActionResult Remove([FromBody] CartRequestModel request)
    {
        try
        {
            ItemModel? item = productService.FindbyId(request.ItemId);
            if (item == null || request.Amount <= 0)
            {
                return BadRequest("invalid item or amount");
            }

            CartModel? cart = cartService.Get(request.CartId);
            if (cart == null)
            {
                return BadRequest("invalid cart");
            }
            cart = cartService.Remove(cart.Id,item, request.Amount);
            return Ok(cart);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500,ex.Message);
        }
    }

    [HttpPatch]
    [Route("/api/cart/clear/{id}")]
    public IActionResult Clear(int id)
    {
        try
        {
            CartModel? cart = cartService.Get(id);
            if (cart == null)
            {
                return BadRequest("invalid cart");
            }
            cart = cartService.Clear(id);
            return Ok(cart);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500,ex.Message);
        }
    }
    
    [HttpPost]
    [Route("/api/cart/checkout/{id}")]
    public IActionResult Checkout(int id)
    {
        try
        {
            CartModel? cart = cartService.Get(id);
            if (cart == null || cart.IsCheckedOut)
            {
                return BadRequest("invalid cart");
            }
            cart = cartService.Checkout(id);
            CartCheckoutResponseModel cartCheckoutResponseModel = new CartCheckoutResponseModel();
            cartCheckoutResponseModel.CartId = cart.Id;
            foreach (var cartTransactionModel in cart.Carts)
            {
                cartCheckoutResponseModel.Total = cartTransactionModel.Item.Price*cartTransactionModel.Amount;
            }
            return Ok(cartCheckoutResponseModel);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500,ex.Message);
        }
    }
    
}
