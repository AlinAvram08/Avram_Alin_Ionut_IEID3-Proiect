using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Avram_Alin_Proiect.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage =
"First name should start with upper-case letter!")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage =
"Last name should start with upper-case letter!")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [StringLength(100)]
        public string? Address { get; set; }
        public string? Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Not a valid 10-digit phone number (Valid form: '0722-123-123'or '0722.123.123' or '0722 123 123'")]
        public string? Phone { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Sale>? Sales { get; set;}
    }
}
