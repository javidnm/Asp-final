using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspFinal.Models.Entity
{
    public class Contact : BaseEntity
    {
        public string Email { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
        public string Answer { get; set; }
        public string Name { get; set; }
        public bool IsReady { get; set; }
    }
}