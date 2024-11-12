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
        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            var existingCustomer = _context.Customers.Find(customer.CustomerId);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.DocumentNumber = customer.DocumentNumber;
            _context.SaveChanges();

            return NoContent();
        }

        // Eliminar un cliente (lógica personalizada si es necesario)
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            // Implementa lógica personalizada para desactivar si es necesario

            _context.SaveChanges();
            return NoContent();
        }
    }
}
