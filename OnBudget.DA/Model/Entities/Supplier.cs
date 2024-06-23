using System.ComponentModel.DataAnnotations;

namespace OnBudget.DA.Model.Entities
{
    public class Supplier
    {
        [Key]
        public string Handle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string Password { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
