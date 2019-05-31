using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspFinal.Models.Entity
{
    public class ProfessionalExperience
    {
        public int Id { get; set; }
        public string Duration { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
    }
}