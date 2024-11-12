namespace Lab11API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Detail> Details { get; set; }
    }
}
