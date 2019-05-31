using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspFinal.Models.Entity
{
    public class Bios
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string SkillLevel { get; set; }
        public string SkillDescription { get; set; }
        public bool IsBar { get; set; }
        public bool IsTag { get; set; }

        public int CategoriesId { get; set; }
        public virtual Categories Categories { get; set; }

        public int SkillsId { get; set; }
        public virtual Skills Skills { get; set; }
    }
}