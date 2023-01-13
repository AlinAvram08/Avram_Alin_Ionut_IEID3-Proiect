using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Avram_Alin_Proiect.Data;
using Avram_Alin_Proiect.Models;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;

namespace Avram_Alin_Proiect.Pages.AutoParts
{
    [Authorize(Roles = "Admin")]
    public class EditModel : AutoPartCategoriesPageModel
    {
        private readonly Avram_Alin_Proiect.Data.Avram_Alin_ProiectContext _context;

        public EditModel(Avram_Alin_Proiect.Data.Avram_Alin_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AutoPart AutoPart { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autopart = await _context.AutoPart
                .Include(b => b.Car)
                .Include(b => b.Supplier)
                .Include(b => b.AutoPartCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (autopart == null)
            {
                return NotFound();
            }
            AutoPart = autopart;

            PopulateAssignedCategoryData(_context, AutoPart);

            ViewData["CarID"] = new SelectList(_context.Set<Car>(), "ID", "CarName");
            ViewData["SupplierID"] = new SelectList(_context.Set<Supplier>(), "ID", "Name", "TaxID", "Address");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            {
                if (id == null)
                {
                    return NotFound();
                }
                var autopartToUpdate = await _context.AutoPart
                .Include(i => i.Car)
                .Include(i => i.AutoPartCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);
                if (autopartToUpdate == null)
                {
                    return NotFound();
                }
                if (await TryUpdateModelAsync<AutoPart>(
                autopartToUpdate, "AutoPart",
                i => i.Name, i => i.Supplier, i => i.Code,
                i => i.Price, i => i.AcquisitionDate, i => i.Car))
                {
                    UpdateAutoPartCategories(_context, selectedCategories, autopartToUpdate);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }

                UpdateAutoPartCategories(_context, selectedCategories, autopartToUpdate);
                PopulateAssignedCategoryData(_context, autopartToUpdate);
                return Page();
            }
        }
    }
}


