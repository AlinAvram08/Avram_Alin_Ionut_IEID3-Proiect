using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Avram_Alin_Proiect.Data;
using Avram_Alin_Proiect.Models;

namespace Avram_Alin_Proiect.Pages.AutoParts
{
    public class DetailsModel : PageModel
    {
        private readonly Avram_Alin_Proiect.Data.Avram_Alin_ProiectContext _context;

        public DetailsModel(Avram_Alin_Proiect.Data.Avram_Alin_ProiectContext context)
        {
            _context = context;
        }

      public AutoPart AutoPart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AutoPart == null)
            {
                return NotFound();
            }

            var autopart = await _context.AutoPart.Include (i=>i.Car).Include(i=>i.Supplier).FirstOrDefaultAsync(m => m.ID == id);
            if (autopart == null)
            {
                return NotFound();
            }
            else 
            {
                AutoPart = autopart;
            }
            return Page();
        }
    }
}
