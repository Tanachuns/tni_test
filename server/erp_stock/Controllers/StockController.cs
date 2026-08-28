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
    [HttpGet()]
    public IActionResult GetAll(int id)
    {
        try
        {
            List<StockModel>? stocks = stockService.GetAll();
            if (stocks == null)
            {
                return BadRequest("invalid stocks");
            }
            return Ok(stocks);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500,ex.Message);
        }
    }

}
