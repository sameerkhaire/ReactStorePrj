using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.API.Data;

namespace Store.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController(StoreContext storeContext) : ControllerBase
  {
    [HttpGet("GetAllProducts")]
    public async Task<IActionResult> GetAllProducts()
    {
      var data = await storeContext.Products.ToListAsync();
      return Ok(data);
    }
    [HttpGet("GetProductById")]
    public async Task<ActionResult> GetProductById([FromQuery] int id)
    {
      var product = await storeContext.Products.FindAsync(id);
      return product == null ? NotFound() : Ok(product);
    }

    [HttpPost("AddProducts")]
    public async Task<IActionResult> AddProducts()
    {
      return Ok();
    }
  }
}
