using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspFinal.Models.Entity
{
    public class AcademicBackgrounds : BaseEntity
    {
        public string Qualification { get; set; }
        public string Degree { get; set; }
        public string UniversityName { get; set; }
        public string YearOfObtention { get; set; }
        public string Details { get; set; }
        public string MediaUrl { get; set; }
    }
}