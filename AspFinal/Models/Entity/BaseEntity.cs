using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspFinal.Models.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? DeletedDate { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? CreatedDate { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? UpdateDate { get; set; }
    }
}