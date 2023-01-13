namespace Avram_Alin_Proiect.Models
{
    public class AutoPartCategory
    {
        public int ID { get; set; }
        public int AutoPartID { get; set; }
        public AutoPart? AutoPart { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }

    }
}
