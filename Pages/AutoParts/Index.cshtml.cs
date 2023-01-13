using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Avram_Alin_Proiect.Data;
using Avram_Alin_Proiect.Models;
using System.Net;
using Microsoft.Data.SqlClient;

namespace Avram_Alin_Proiect.Pages.AutoParts
{
    public class IndexModel : PageModel
    {
        private readonly Avram_Alin_Proiect.Data.Avram_Alin_ProiectContext _context;

        public IndexModel(Avram_Alin_Proiect.Data.Avram_Alin_ProiectContext context)
        {
            _context = context;

        }

        public IList<AutoPart> AutoPart { get; set; } = default!;
        public AutoPartData AutoPartD { get; set; }
        public int AutoPartID { get; set; }
        public int CategoryID { get; set; }

        public string NameSort { get; set; }
        public string CarSort { get; set; }

        public string CodeSort { get; set; }

        public string SupplierSort { get; set; }
        public string PriceSort { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {

            AutoPartD = new AutoPartData();

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CarSort = String.IsNullOrEmpty(sortOrder) ? "car_desc" : "";
            SupplierSort = String.IsNullOrEmpty(sortOrder) ? "suppl_desc" : "";
            CodeSort = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
            PriceSort = String.IsNullOrEmpty(sortOrder) ? "price_asc" : "";

            CurrentFilter = searchString;

            AutoPartD.AutoParts = await _context.AutoPart
            .Include(b => b.Car)
            .Include(b => b.Supplier)
            .Include(b => b.AutoPartCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                AutoPartD.AutoParts = AutoPartD.AutoParts.Where(s => s.Car.CarName.Contains(searchString)

               || s.Supplier.Name.Contains(searchString)
               || s.Name.Contains(searchString));
            
            }



                if (id != null)
            {
                AutoPartID = id.Value;
                AutoPart autopart = AutoPartD.AutoParts
                .Where(i => i.ID == id.Value).Single();
                AutoPartD.Categories = autopart.AutoPartCategories.Select(s => s.Category);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    AutoPartD.AutoParts = AutoPartD.AutoParts.OrderByDescending(s =>
                   s.Name);
                    break;
                case "car_desc":
                    AutoPartD.AutoParts = AutoPartD.AutoParts.OrderByDescending(s =>
                   s.Car.CarName);
                    break;
                case "suppl_desc":
                    AutoPartD.AutoParts = AutoPartD.AutoParts.OrderByDescending(s =>
                   s.Supplier.Name);
                    break;
                case "price_asc":
                    AutoPartD.AutoParts = AutoPartD.AutoParts.OrderBy(s =>
                   s.Price);
                    break;
            }
        }
    }
}

