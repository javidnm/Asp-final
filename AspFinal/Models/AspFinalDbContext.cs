using AspFinal.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspFinal.Models
{
    public class AspFinalDbContext : DbContext
    {
        public AspFinalDbContext()
            :base("name=cString")
        {

        }
        public DbSet<AcademicBackgrounds> AcademicBackgrounds { get; set; }
        public DbSet<Bios> Bios { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<PersonDetails> PersonDetails { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<ProfessionalExperience> ProfessionalExperience { get; set; }
        public DbSet<Contact> Contact { get; set; }
    }
}