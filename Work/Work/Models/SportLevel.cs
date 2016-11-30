using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Work.Models
{
    public class SportLevel
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public List<User> Users { get; set; }
    }
}