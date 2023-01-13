using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Avram_Alin_Proiect.Models
{
    public class AutoPartData
    {
        public IEnumerable<AutoPart> AutoParts { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<AutoPartCategory> AutoPartCategories { get; set; }
    }
}
