using System.Runtime.InteropServices.JavaScript;
using erp_stock.Interfaces;
using erp_stock.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace erp_stock.Controllers;

[Route("api/[controller]")]
public class CartController(IConfiguration config,ICartService cartService) : Controller
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
    
    
}
