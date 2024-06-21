using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.DA.Model.Entities
{
    public class Picture
    {
        public int Id { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
        public int ProductId { get; set; }
    }
}
