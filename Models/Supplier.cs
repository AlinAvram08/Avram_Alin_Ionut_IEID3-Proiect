using System.ComponentModel.DataAnnotations;

namespace Avram_Alin_Proiect.Models
{
    public class Supplier
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage =
"Supplier name should start with upper-case letter!")]
        [Required, StringLength(30, MinimumLength = 3)]
        [Display(Name = "Supplier Name")]
        public string Name { get; set; }

        [Display(Name="Tax Identification Number")]
        public int TaxID { get; set; }

        [StringLength(100)]
        public string Address { get; set; }
        public ICollection<AutoPart>? Autoparts { get; set; } //navigation property
    }
}
