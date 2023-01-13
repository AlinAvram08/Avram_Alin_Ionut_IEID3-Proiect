using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Avram_Alin_Proiect.Models;

namespace Avram_Alin_Proiect.Data
{
    public class Avram_Alin_ProiectContext : DbContext
    {
        public Avram_Alin_ProiectContext (DbContextOptions<Avram_Alin_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Avram_Alin_Proiect.Models.AutoPart> AutoPart { get; set; } = default!;

        public DbSet<Avram_Alin_Proiect.Models.Car> Car { get; set; }

        public DbSet<Avram_Alin_Proiect.Models.Category> Category { get; set; }

        public DbSet<Avram_Alin_Proiect.Models.Supplier> Supplier { get; set; }

        public DbSet<Avram_Alin_Proiect.Models.Customer> Customer { get; set; }

        public DbSet<Avram_Alin_Proiect.Models.Sale> Sale { get; set; }
    }
}
