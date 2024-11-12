namespace Lab11API.Models
{
    public class Detail
    {
        public int DetailId { get; set; } // Clave primaria
        public int InvoiceId { get; set; } // Llave foránea a Invoice
        public Invoice Invoice { get; set; } // Navegación a Invoice

        public int ProductId { get; set; } // Llave foránea a Product
        public Product Product { get; set; } // Navegación a Product

        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Subtotal { get; set; }
    }
}
