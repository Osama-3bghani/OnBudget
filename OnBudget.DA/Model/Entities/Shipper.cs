namespace OnBudget.DA.Model.Entities
{
    public class Shipper
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
    }
}
