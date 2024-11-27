namespace Lab11API.Models
{
    public class Customer
    {
        public int CustomerId { get; set; } // Clave primaria
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; } // Relación uno a muchos con Invoices
    }

}
