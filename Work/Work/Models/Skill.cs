using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Work.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SkillUsers> SkillsUsers { get; set; }


    }
}