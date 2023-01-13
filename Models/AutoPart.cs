using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Avram_Alin_Proiect.Models
{
    public class AutoPart
    {
        public int ID { get; set; }
        [RegularExpression(@"^[a-z]+[a-z\s]*$", ErrorMessage =
"Auto part name should start with lower-case letter!")]
        [Required, StringLength(120, MinimumLength = 3)]
        [Display(Name = "Auto Part Name")]
        public string Name { get; set; }

        [Required, StringLength(30, MinimumLength = 3)]
        [Display(Name = "Auto Part Code")]
        public string Code { get; set; }

        public int? SupplierID { get; set; }
        public Supplier? Supplier { get; set; } 

        [Range(0.5, 50000)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Acquisition Date")]
        public DateTime AcquisitionDate { get; set; }
        public int? CarID { get; set; }

        public Car? Car { get; set; } 
        [Display(Name = "Categories")]
        public ICollection<AutoPartCategory>? AutoPartCategories { get; set; }


    }
}
