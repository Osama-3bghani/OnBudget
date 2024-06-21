using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.DA.Model.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        //public DateTime RequiredDate { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
        //public int OrderNumber { get; set; }
        //public ICollection<Bill> Bills { get; set; } = new HashSet<Bill>();
        //public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
        //public ICollection<Supplier> Suppliers { get; set; } = new HashSet<Supplier>();
    }
}
