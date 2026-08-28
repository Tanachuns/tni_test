using System.Runtime.InteropServices.JavaScript;
using erp_stock.Interfaces;
using erp_stock.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace erp_stock.Controllers;

[Route("api/[controller]")]
public class ProductsController(IConfiguration config,IProductService productService) : Controller
{
    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            List<ItemModel> items = productService.All();
            return Ok(items);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500,ex.Message);
        }
    }

}
