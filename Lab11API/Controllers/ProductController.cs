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
            product.IsActive = true; // Asegúrate de que el nuevo producto esté activo
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        // Actualizar un producto
        [HttpPut]
        public IActionResult Update(Product product)
        {
            var existingProduct = _context.Products.Find(product.ProductId);
            if (existingProduct == null || !existingProduct.IsActive)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
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

            product.IsActive = false; // Desactivar el producto
            _context.SaveChanges();

            return NoContent();
        }
    }
}
