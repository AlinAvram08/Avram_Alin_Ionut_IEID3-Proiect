using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Avram_Alin_Proiect.Data;
using Avram_Alin_Proiect.Models;
using Avram_Alin_Proiect.Models.ViewModels;
using System.Security.Policy;

namespace Avram_Alin_Proiect.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly Avram_Alin_Proiect.Data.Avram_Alin_ProiectContext _context;

        public IndexModel(Avram_Alin_Proiect.Data.Avram_Alin_ProiectContext context)
        {
            _context = context;
        }
        


        public IList<Car> Car { get;set; } = default!;
        public CarIndexData CarData { get; set; }
        public int CarID { get; set; }
        public int AutoPartID { get; set; }

        public async Task OnGetAsync(int? id, int? autopartID)
        {
            CarData = new CarIndexData();
            CarData.Cars = await _context.Car
            .Include(i => i.Autoparts)
            .OrderBy(i => i.CarName)
            .ToListAsync();
            if (id != null)
            {
                CarID = id.Value;
                Car car = CarData.Cars
                .Where(i => i.ID == id.Value).Single();
                CarData.AutoParts = car.Autoparts;
            }
        }
    }
}
