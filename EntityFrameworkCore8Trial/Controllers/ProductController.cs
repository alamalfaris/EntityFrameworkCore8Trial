using EntityFrameworkCore8Trial.Database;
using EntityFrameworkCore8Trial.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore8Trial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ProductController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _context.Product.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult> GetProduct(int productId)
        {
            var product = await _context.Database
                .SqlQuery<ProductDto>($@"
                    SELECT [Name]
                    FROM Product
                    WHERE Id = {productId}")
                .FirstOrDefaultAsync();

            return Ok(product);
        }
    }
}
