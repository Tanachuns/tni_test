using Microsoft.AspNetCore.Mvc;

namespace erp_stock.Controllers;

[Route("api/[controller]")]
public class ProductsController(IConfiguration config) : Controller
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }

}
