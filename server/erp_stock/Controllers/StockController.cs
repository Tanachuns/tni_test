using System.Runtime.InteropServices.JavaScript;
using erp_stock.Interfaces;
using erp_stock.Models;
using erp_stock.Models.http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace erp_stock.Controllers;

[Route("api/[controller]")]
public class StockController(IConfiguration config,ICartService cartService,IProductService productService,IStockService stockService) : Controller
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

    [HttpPost]
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
            cartService.Add(cart.Id,item, request.Amount);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500,ex.Message);
        }
    }
    [HttpPatch]
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
            cartService.Remove(cart.Id,item, request.Amount);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500,ex.Message);
        }
    }
}
