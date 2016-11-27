using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportTourism.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public DateTime Birthday { get; set; }
        public string MyProperty { get; set; }
        public string ContactTelEMail { get; set; }
        public bool IsSportsman { get; set; }
        public string Gender { get; set; }
        public string Skills { get; set; }
        public int OrderID { get; set; }

    }
}