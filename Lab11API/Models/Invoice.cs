namespace Lab11API.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; } // Clave primaria
        public string Number { get; set; }
        public DateTime Date { get; set; }

        // Llave foránea
        public int CustomerId { get; set; } // Relación con Customer
        public Customer Customer { get; set; } // Navegación a Customer
    }
}
