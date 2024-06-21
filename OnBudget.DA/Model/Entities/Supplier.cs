using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.DA.Model.Entities
{
    public class Supplier
    {
        //public int Id { get; set; }
        [Key]
        public string Handle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string Password { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        //public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        //public ICollection<Shipper> Shippers { get; set; } = new HashSet<Shipper>();
        //public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
        //public int ShipperId { get; set; }
    }
}
