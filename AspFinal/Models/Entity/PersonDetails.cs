using System.ComponentModel;

namespace AspFinal.Models.Entity
{
    public class PersonDetails : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public string Experience { get; set; }
        public string Degree { get; set; }
        public string CareerLevel { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        [DisplayName(" ")]
        public string MediaUrl { get; set; }
    }
}