using Microsoft.AspNetCore.Mvc;
using Lab11API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lab11API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public InvoiceController(InvoiceContext context)
        {
            _context = context;
        }

        // Insertar una nueva factura
        [HttpPost]
        public void Insert(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }

        // Insertar lista de facturas para un cliente
        [HttpPost]
        public void InsertInvoicesForCustomer(int customerId, [FromBody] List<Invoice> invoices)
        {
            foreach (var invoice in invoices)
            {
                invoice.CustomerId = customerId;
                _context.Invoices.Add(invoice);
            }
            _context.SaveChanges();
        }

        // Insertar detalles de factura
        [HttpPost]
        public void InsertInvoiceDetails(int invoiceId, [FromBody] List<Detail> details)
        {
            foreach (var detail in details)
            {
                detail.InvoiceId = invoiceId;
                _context.Details.Add(detail);
            }
            _context.SaveChanges();
        }
    }
}
