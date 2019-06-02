using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspFinal.Models.Entity
{
    public class Admin : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}