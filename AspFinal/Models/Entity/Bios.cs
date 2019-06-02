using System.ComponentModel;

namespace AspFinal.Models.Entity
{
    public class Bios : BaseEntity
    {
        public string Description { get; set; }
        public string SkillLevel { get; set; }
        public string SkillDescription { get; set; }
        public bool IsBar { get; set; }
        public bool IsTag { get; set; }
        [DisplayName("Category")]
        public int CategoriesId { get; set; }
        public virtual Categories Categories { get; set; }

        [DisplayName("Skills")]
        public int SkillsId { get; set; }
        public virtual Skills Skills { get; set; }
    }
}