using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Avram_Alin_Proiect.Data;
using Avram_Alin_Proiect.Models;

namespace Avram_Alin_Proiect.Pages.Sales
{
    public class DetailsModel : PageModel
    {
        private readonly Avram_Alin_Proiect.Data.Avram_Alin_ProiectContext _context;

        public DetailsModel(Avram_Alin_Proiect.Data.Avram_Alin_ProiectContext context)
        {
            _context = context;
        }

      public Sale Sale { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale.Include(b=>b.AutoPart).Include(b=>b.Customer).FirstOrDefaultAsync(m => m.ID == id);
            if (sale == null)
            {
                return NotFound();
            }
            else 
            {
                Sale = sale;
            }
            return Page();
        }
    }
}
