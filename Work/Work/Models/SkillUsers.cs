using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Work.Models
{
    public class SkillUsers
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Skill Skill { get; set; }
        public int SkilId { get; set; }


    }
}