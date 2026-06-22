using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>();

        // POST /api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            product.Id = products.Count + 1;
            products.Add(product);

            return Ok(product);
        }

        // GET /api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { error = "Id phải là số nguyên dương" });
            }

            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(new { error = "Không tìm thấy sản phẩm" });
            }

            return Ok(product);
        }
    }
}