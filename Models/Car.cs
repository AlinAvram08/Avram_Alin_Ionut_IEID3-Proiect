using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Avram_Alin_Proiect.Models
{
    public class Car
    {
       public int ID { get; set; }

       [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage =
"Car name should start with upper-case letter!")]
       [Required, StringLength(30, MinimumLength = 3)]
       [Display(Name = "Car Name")]
       public string CarName { get; set; }

       [Display(Name = "Vehicle Identification Number")]
       [Required, StringLength(30, MinimumLength = 3)]
       public string VeIdNumber { get; set; }
       public ICollection<AutoPart>? Autoparts { get; set; } //navigation property
        
        
    }
}
