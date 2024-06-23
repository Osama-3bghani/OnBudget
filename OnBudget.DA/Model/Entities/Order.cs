namespace OnBudget.DA.Model.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
