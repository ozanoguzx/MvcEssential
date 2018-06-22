namespace MVC_Session.Models
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInstock { get; set; }
        public int CategoryId { get; set; }
        public short Quantity { get; set; }
    }
}