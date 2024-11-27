using Microsoft.AspNetCore.Mvc;
using Lab11API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lab11API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public CustomerController(InvoiceContext context)
        {
            _context = context;
        }

        // Obtener todos los clientes
        [HttpGet]
        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        // Insertar un nuevo cliente
        [HttpPost]
        public void Insert(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        // Actualizar un cliente
        [HttpPut("{id}")]
        public IActionResult UpdateDocumentNumber(int id, [FromBody] Customer updatedCustomer)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.DocumentNumber = updatedCustomer.DocumentNumber;
            customer.Email = updatedCustomer.Email;
            _context.SaveChanges();
            return NoContent();
        }

        // Eliminar un cliente
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
