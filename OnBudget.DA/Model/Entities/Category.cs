using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.DA.Model.Entities
{
    public class Category
    {
        //public int Id { get; set; }
        [Key]
        public string Name { get; set; }
        //public string Description { get; set; }
        public ICollection<Product> Products { get; set; }=new HashSet<Product>();

        
    }
}
