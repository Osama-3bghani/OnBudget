using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //public ICollection<Shipper> Shippers { get; set; } = new HashSet<Shipper>();
        //public ICollection<Supplier> Suppliers { get; set; } = new HashSet<Supplier>();
        //public ICollection<Bill> Bills { get; set; } = new HashSet<Bill>();
    }
}
