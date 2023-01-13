using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Avram_Alin_Proiect.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public ICollection<AutoPartCategory>? AutoPartCategories { get; set; }
    }
}
