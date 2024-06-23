namespace OnBudget.DA.Model.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Handle { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
