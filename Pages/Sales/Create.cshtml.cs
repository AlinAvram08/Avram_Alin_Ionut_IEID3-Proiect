using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Avram_Alin_Proiect.Data;
using Avram_Alin_Proiect.Models;

namespace Avram_Alin_Proiect.Pages.Sales
{
    public class CreateModel : PageModel
    {
        private readonly Avram_Alin_Proiect.Data.Avram_Alin_ProiectContext _context;

        public CreateModel(Avram_Alin_Proiect.Data.Avram_Alin_ProiectContext context)
        {
            _context = context;
        }


        public IActionResult OnGet()
        {
        ViewData["AutoPartID"] = new SelectList(_context.AutoPart, "ID", "Name");
        ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Sale Sale { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sale.Add(Sale);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
