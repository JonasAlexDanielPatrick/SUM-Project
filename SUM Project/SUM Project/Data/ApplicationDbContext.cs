using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SUM_Project.Models;

namespace SUM_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<HåndværkstimerModel>().HasKey(c => new { c.tilbud_id, c.med_id });
        }

        public DbSet<SUM_Project.Models.MedarbejderModel> Medarbejder { get; set; }


        public DbSet<SUM_Project.Models.TilbudModel> Tilbud { get; set; }

        public DbSet<SUM_Project.Models.HåndværkstimerModel> TilbudHåndværkstimer { get; set; }

    }
}
