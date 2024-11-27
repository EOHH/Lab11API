namespace Lab11API.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Total { get; set; } // Agregado para el cálculo del total
        public virtual ICollection<Detail> Details { get; set; }
    }
}
