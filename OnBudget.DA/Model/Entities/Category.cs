using System.ComponentModel.DataAnnotations;

namespace OnBudget.DA.Model.Entities
{
    public class Category
    {
        [Key]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();


    }
}
