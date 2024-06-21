using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.DA.Model.Entities
{
    public class Shipper
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        //public int CustomerId { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
    }
}
