using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.DA.Model.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double UnitPrice { get; set; }
        public string Color { get; set; }
        public string CategoryName { get; set; }
        public string SupplierHandle { get; set; }
        public ICollection<Picture> Pictures { get; set; } = new HashSet<Picture>();
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
        //public ICollection<Order> Orders { get; set; } = new List<Order>();
        //public ICollection<Supplier> Suppliers { get; set; } = new HashSet<Supplier>();
    }
}
