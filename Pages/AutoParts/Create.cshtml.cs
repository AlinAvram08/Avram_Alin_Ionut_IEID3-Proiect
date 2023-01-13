using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Avram_Alin_Proiect.Data;
using Avram_Alin_Proiect.Models;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;

namespace Avram_Alin_Proiect.Pages.AutoParts
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : AutoPartCategoriesPageModel
    {
        private readonly Avram_Alin_Proiect.Data.Avram_Alin_ProiectContext _context;

        public CreateModel(Avram_Alin_Proiect.Data.Avram_Alin_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SupplierID"] = new SelectList(_context.Set<Supplier>(), "ID", "Name");
            ViewData["CarID"] = new SelectList(_context.Set<Car>(), "ID", "CarName");

            var autopart = new AutoPart();
            autopart.AutoPartCategories = new List<AutoPartCategory>();
            PopulateAssignedCategoryData(_context, autopart);

            return Page();
        }

        [BindProperty]
        public AutoPart AutoPart { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newAutoPart = new AutoPart();
            if (selectedCategories != null)
            {
                newAutoPart.AutoPartCategories = new List<AutoPartCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new AutoPartCategory()
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newAutoPart.AutoPartCategories.Add(catToAdd);
                }
            }
            AutoPart.AutoPartCategories = newAutoPart.AutoPartCategories;
            _context.AutoPart.Add(AutoPart);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            PopulateAssignedCategoryData(_context, AutoPart);
            return Page();
        }

    }
}
