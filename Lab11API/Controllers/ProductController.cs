using Microsoft.AspNetCore.Mvc;
using Lab11API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lab11API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public ProductController(InvoiceContext context)
        {
            _context = context;
        }

        // Obtener todos los productos activos
        [HttpGet]
        public List<Product> GetAll()
        {
            return _context.Products.Where(p => p.IsActive).ToList();
        }

        // Insertar un nuevo producto
        [HttpPost]
        public void Insert(Product product)
        {
            product.IsActive = true;
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        // Actualizar precio de un producto
        [HttpPut("{id}")]
        public IActionResult UpdatePrice(int id, [FromBody] double newPrice)
        {
            var product = _context.Products.Find(id);
            if (product == null || !product.IsActive)
            {
                return NotFound();
            }

            product.Price = newPrice;
            _context.SaveChanges();
            return NoContent();
        }

        // Desactivar un producto (eliminar)
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null || !product.IsActive)
            {
                return NotFound();
            }

            product.IsActive = false;
            _context.SaveChanges();
            return NoContent();
        }

        // Eliminar lista de productos
        [HttpDelete]
        public IActionResult DeleteList([FromBody] List<int> productIds)
        {
            var products = _context.Products.Where(p => productIds.Contains(p.ProductId) && p.IsActive).ToList();
            if (!products.Any())
            {
                return NotFound();
            }

            products.ForEach(p => p.IsActive = false);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
