using System.ComponentModel.DataAnnotations;

namespace Avram_Alin_Proiect.Models
{
    public class Sale
    {
        public int ID { get; set; }
        public int? CustomerID { get; set; }
        public Customer? Customer { get; set; }
        public int? AutoPartID { get; set; }
        public AutoPart? AutoPart { get; set; }

        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }

    }
}
