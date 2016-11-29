using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportTourism.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string AboutMe { get; set; }
        public string Gender { get; set; }
        public SportLevel SportLevel { get; set; } //много user -> один SportLevel
        public List<Skills> Skills { get; set; } //один user -> много Skills

        public List<OrganizationsUsers> OrganizationsUsers { get; set; } //?!?!?!? один user -> много OrganizationsUsers
        public List<EventsUsers> EventsUsers { get; set; } //?!?!? один user -> много EventsUsers 
    }
}